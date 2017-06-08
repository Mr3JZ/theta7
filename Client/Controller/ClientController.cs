using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Model;

using System.IO;
using System.Net;

namespace Client
{
    public class ClientController : MarshalByRefObject, IClient
    {
        private readonly IServer server;
        private User currentUser;
        private string tempFilePath;
        private string tempConfID;
        private string tempAbstractMessage;
        public ClientController(IServer server)
        {
            this.server = server;
            this.currentUser = null;
        }
        /*
         * Returns the user that logged in.
         * Returns an User object
         */
        public User getCurrentUser()
        {
            return currentUser;
        }

        //---------------CONFERENCE

        public void updatedConference(Conference c)
        {
            server.UpdateConference(c);
        }

        /*
         * Returns all conferences
         */
        public List<Model.Conference> getAllConferences()
        {
            return server.GetConferences();
        }

        /*Filters the conferences by name:String,edition:String,city:String
         * Return 1 conference*/
        public Model.Conference getConference(string name, string edition, string city)
        {
            List<Model.Conference> allConferences = getAllConferences();
            foreach (Model.Conference conference in allConferences)
            {
                if (conference.Name.Equals(name) && conference.Edition.Equals(edition) && conference.City.Equals(city))
                    return conference;
            }
            return null;
        }

        /**
         * Filters conferences by id.Id:int is unique
         * returns 1 conferences or null if there is no conference with the given id*/
        public Model.Conference getConferenceById(int id)
        {
            List<Model.Conference> allConferences = getAllConferences();
            foreach (Model.Conference conference in allConferences)
            {
                if (conference.Id == id)
                    return conference;
            }
            return null;
        }

        /*
         * Return all conferences for the current user*/
        public List<Model.Conference> getMyConferences() 
        {
            List<Model.Conference> allConferences = getAllConferences();
            List<Model.Conference> myConferences = new List<Model.Conference>();
            foreach (Conference conference in allConferences)
            {
                foreach (Participant participant in conference.Participants)
                {
                    if (participant.User.Name.Equals(currentUser.Name))
                    {
                        myConferences.Add(conference);
                        break;
                    }
                }
            }
            return myConferences;
        }

        /*Adds a new conference in the data base.
         * Returns Exception if dates are not in chronological order*/
        public void AddConference(string name, string edition, List<string> topics, DateTime deadlineAbstract,
                DateTime deadlineComplet, DateTime deadlineBidding, DateTime deadlineEvaluation, DateTime deadlineParticipation,
                string city, string country, string website, double admissionPrice, DateTime beginDate, DateTime endDate)
        {
            Conference conference = new Conference(-1, name, edition, topics, deadlineAbstract, deadlineComplet, deadlineBidding, deadlineEvaluation, deadlineParticipation,
                city, country, website, admissionPrice, beginDate, endDate);
            server.AddConference(conference);
        }

        //---------------PAPER

        /*Returns all papers*/
        public List<Model.Paper> getPapers(Conference conference)
        {
            return conference.Papers.Where(p => { return p.Uploader.Username == currentUser.Username; }).ToList();
        }

        /*Returns all papers for a conference*/
        public List<Paper> getAllPapersConference(Conference conference)
        {
            return conference.Papers;
        }

        ///USER

           /*
            * Login function.User is verified by username&password
            */
        public bool login(string username, string password)
        {
            try
            {
                User user = new User(username, password);
                currentUser = server.Login(user, this);
                return true;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }

        /*User is being disconnected from the app
         * He is also being removed from active users list*/
        public void logout()
        {
            try
            {
                server.Logout(currentUser, this);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /*A new user is added in data base.
         */
        public bool register(string username, string password, string name, string affiliation, string email, string website, bool isSpecial)
        {
            try
            {
                User user = new User();
                user.Username = username;
                user.Password = password;
                user.Name = name;
                user.Affiliation = affiliation;
                user.Email = email;
                user.isSpecial = isSpecial;
                user.Website = website;
                return server.Register(user);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }

        /*Returns a list with all the users*/
        public List<Model.User> GetAllUsers()
        {
            return server.GetAllUsers();
        }
        /*Returns the rank of the current user for a particular conference*/
        public string getMyRank(string name, string edition, string city)
        {
            List<Model.Conference> allConferences = getAllConferences();
            foreach (Model.Conference conference in allConferences)
            {
                if (conference.Name.Equals(name) && conference.Edition.Equals(edition) && conference.City.Equals(city))
                    foreach (Model.Participant participant in conference.Participants)
                        if (participant.User.Name.Equals(currentUser.Name))
                        {
                            if (participant.IsChair)
                                return "Chair";
                            if (participant.IsCochair)
                                return "CoChair";
                            if (participant.CanBePCMember)
                                return "PCMember";
                            else
                                return "NormalUser";
                        }
            }
            return "Unregistered";
        }

        /*Returns the rank of the current user for a particular conference*/
        public string getMyRank(int confId)
        {
            List<Model.Conference> allConferences = getAllConferences();
            foreach (Model.Conference conference in allConferences)
            {
                if (conference.Id==confId)
                    foreach (Model.Participant participant in conference.Participants)
                        if (participant.User.Name.Equals(currentUser.Name))
                        {
                            if (participant.IsChair)
                                return "Chair";
                            if (participant.IsCochair)
                                return "CoChair";
                            if (participant.CanBePCMember)
                                return "PCMember";
                            else
                                return "NormalUser";
                        }
            }
            return "Unregistered";
        }

        public List<Model.User> GetSpecialUsers()
        {
            return server.GetSpecialUsers();
        }

        //--------------PARTICIPANT
        
        /*Returns a list of all the chairs for a conference
         * */
        public List<Model.Participant> getChairs(Conference conference)
        {
            List<Model.Participant> chairList = new List<Model.Participant>();
            foreach (Model.Participant participant in conference.Participants)
            {
                if (participant.IsChair || participant.IsCochair)
                    chairList.Add(participant);
            }
            return chairList;
        }

        /*Returns a list of pc members*/
        public List<Model.Participant> getPCMembers(Conference conference)
        {
            List<Model.Participant> memberList = new List<Model.Participant>();
            foreach (Model.Participant participant in conference.Participants)
            {
                if (participant.CanBePCMember)
                    memberList.Add(participant);
            }
            return memberList;
        }

        /*Adds a new participant in data base*/
        public void addParticipant(Participant p)
        {
            server.AddParticipant(p);
        }

        /*Adds a new payment in data base*/
        public void addPayment(Participant p, int paidSum, Conference conf)
        {
            server.NewPayment(p, paidSum, conf);
        }

        ///REVIEW

         /*Returns a list of the reviews for a paper*/
        public List<Review> getReviewsByPaper(string title)
        {
            return new List<Review>();
        }
        public List<Review> getReviewsByPaper(int paperId)
        {
            return server.GetReviewsByPaper(paperId);
        }
        public void addReview(int paperId, Review r)
        {
            server.AddReview(paperId, r);
        }

        ///MESSAGES

        public void AddMessage(string messageBody)
        {
            Message message = new Message(-1, messageBody, currentUser.IdUser);
            server.AddMessage(message);
        }
        public void DeleteMessage(Message message)
        {
            server.DeleteMessage(message);
        }
        public List<Message> GetMyMessages(int userID)
        {
            return server.GetUserMessages(userID).OrderBy(x => x.UserId).Reverse().ToList();
        }
        public List<Message> GetMyMessages()
        {
            return server.GetUserMessages(currentUser.IdUser).OrderBy(x => x.UserId).Reverse().ToList();
        }

        ///FTP
        public void createFolder(string conferenceID)
        {
            string folderName = conferenceID.ToString();
            try
            {
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create("ftp://issftp.ddns.net/" + folderName + "/");
                req.Method = WebRequestMethods.Ftp.ListDirectory;
                req.Credentials = new NetworkCredential("IssUser", "password");

                using (FtpWebResponse response = (FtpWebResponse)req.GetResponse())
                {
                    // Folder already exists
                    //Console.WriteLine("L am gasit");
                }
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    FtpWebResponse response = (FtpWebResponse)ex.Response;
                    if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                    {
                        // Folder not found, create it
                        //Console.WriteLine("Nu l am gasit");
                        WebRequest request = WebRequest.Create("ftp://issftp.ddns.net/" + folderName + "/");
                        request.Method = WebRequestMethods.Ftp.MakeDirectory;
                        request.Credentials = new NetworkCredential("IssUser", "password");
                        using (var resp = (FtpWebResponse)request.GetResponse())
                        {
                            Console.WriteLine(resp.StatusCode);
                        }
                    }
                }
            }


        }
        public void createFile(string conferenceID, string filepath) //it will update if exists
        {
            string folderName = conferenceID.ToString();
            string filename = filepath.Split('\\').Last();
            Console.WriteLine(filename);
            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential("IssUser", "password");
                client.UploadFile("ftp://issftp.ddns.net/" + folderName + "/" + filename, "STOR", filepath);
            }
        }

        public void rememberPaper(string filepath, int confID)
        {
            this.tempFilePath = filepath;
            this.tempConfID = confID.ToString();
        }
        public void rememberAbstract(string abstractMessage)
        {
            tempAbstractMessage = abstractMessage;
        }
        public bool saveChanges(int confId, string title, string domain, string subdomain, string topic)
        {
            createFolder(tempConfID);
            createFile(tempConfID, tempFilePath);
            Paper paper = new Paper();
            paper.ConferenceId = confId;
            paper.Uploader = currentUser;
            paper.Title = title;
            paper.Filepath = tempFilePath;
            paper.Resume = tempAbstractMessage;
            paper.Domain = domain;
            paper.Subdomain = subdomain;
            paper.Topic = topic;
            paper.Bids = new Dictionary<Participant, int>();
            paper.Reviewers = new List<Participant>();
            paper.Reviews = new List<Review>();
            paper.AdditionalAuthors = new List<Author>();
            paper.Status = Status.PENDING;
            return server.addPaper(paper);
        }
        public void revertRemembers()
        {
            tempFilePath = "";
            tempConfID = "";
            tempAbstractMessage = "";
        }
        public void removePaper(int id)
        {
            server.removePaper(id);
        }
        public bool savePaperToDisk(string filepath, int conferenceID, string filename)
        {
            using (WebClient request = new WebClient())
            {
                request.Credentials = new NetworkCredential("IssUser", "password");
                byte[] fileData = request.DownloadData("ftp://issftp.ddns.net/" + conferenceID + "/" + filename);

                using (FileStream file = File.Create(filepath))
                {
                    file.Write(fileData, 0, fileData.Length);
                    file.Close();
                }
                return true;
            }
        }

        public void AddBid(Model.Participant bidder,int confId, int selectedPaper, int bidValue)
        {
            server.AddBid(bidder, confId, selectedPaper, bidValue);
        public void addRoom(int confId, string roomName, int capacity, string street, string city, string postalCode, DateTime beginDate, DateTime endDate)
        {
            server.AddAvailableRoom(confId, roomName, capacity, street, city, postalCode, beginDate, endDate);
        }
    }
}