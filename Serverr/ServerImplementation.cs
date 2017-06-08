using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Persistence.Repository;
using Persistence;

namespace Server
{
    public class ServerImplementation : MarshalByRefObject, IServer
    {
        //toate repo-urile...
        private RepoUserDB repoUser;
        private RepoAvailableRoomDB repoAvailableRoom;
        private RepoConference repoConference;
        private RepoMessageDB repoMessage;
        private RepoPaperDB repoPaper;
        private RepoParticipantDB repoParticipant;
        private RepoPayment repoPayment;
        private RepoSessionDB repoSession;
        

        private readonly IDictionary<String, IClient> loggedClients;

        public ServerImplementation(RepoUserDB repoUser, RepoAvailableRoomDB repoAvailableRoom, RepoConference repoConference, RepoMessageDB repoMessage, RepoPaperDB repoPaper, RepoParticipantDB repoParticipant, RepoPayment repoPayment, RepoSessionDB repoSession)
        {
            this.repoUser = repoUser;
            this.repoAvailableRoom = repoAvailableRoom;
            this.repoConference = repoConference;
            this.repoMessage = repoMessage;
            this.repoPaper = repoPaper;
            this.repoParticipant = repoParticipant;
            this.repoPayment = repoPayment;
            this.repoSession = repoSession;
            loggedClients = new Dictionary<String, IClient>();

            
        }

        public List<Model.Conference> GetConferences()
        {
            var all= repoConference.getConferences();

            foreach(var conf in all)
            {
                conf.Papers = repoPaper.GetByConference(conf.Id);
                conf.Participants = repoParticipant.GetByConference(conf.Id);
                conf.Sessions = repoSession.GetByConference(conf.Id);
            }

            return all;

        }
        
        /*
         * Override for 6 min timer so we don't get .net remoting exception*/
        public override object InitializeLifetimeService()
        {
            return null;
        }

        public Model.Conference GetConference(int id)
        {
            var conf= repoConference.getConference(id);

            conf.Papers = repoPaper.GetByConference(conf.Id);
            conf.Participants = repoParticipant.GetByConference(conf.Id);
            conf.Sessions = repoSession.GetByConference(conf.Id);

            return conf;
        }

        public Model.User Login(Model.User u, IClient client)
        {

            if (loggedClients.ContainsKey(u.Username) == true)
                throw new ServerException("User already logged in");
            
            List<Model.User> allUsers = repoUser.GetAll();
            foreach (Model.User user in allUsers)
                if (user.Username.Equals(u.Username) && user.Password.Equals(u.Password))
                {
                    loggedClients.Add(u.Username, client);
                    return user;
                }

            throw new ServerException("Invalid user");
        }

        public void Logout(Model.User u, IClient client)
        {
            if (loggedClients.ContainsKey(u.Username))
            {
                loggedClients.Remove(u.Username);
                return;
            }
            throw new ServerException("User not logged in");//User is not logged in
            
        }
        public bool Register(Model.User user)
        {
            List<Model.User> all = repoUser.GetAll();
            if (repoUser.GetAll().Any(x => x.Username.Equals(user.Username)))
                return false;
            //Verifica daca user-ul exista in BD
            ///daca exista arunca exceptie
            repoUser.Add(user);
            return true;
        }


        public void AddParticipant(Participant p)
        {
            repoParticipant.Add(p);
        }
        /*Adauga un payment*/
        public void NewPayment(Model.Participant p, int nrTickets,Model.Conference conf)
        {
            repoPayment.addPayment(p, nrTickets,conf);
            
        }
        
        public void UpdateConference(Model.Conference c)
        {

            repoConference.updateConference(c);
        }

        public void UpdatePaper(Model.Paper p)
        {
            //updateaza o lucrare, eventual notifica 
            throw new NotImplementedException();
        }

        public List<Model.Review> GetReviewsByPaper(int paperId)
        {
            return repoPaper.GetReviewsByPaper(paperId);
        }

        public void AddReview(int paperId, Model.Review r)
        {
            repoPaper.AddReview(paperId, r);
        }

        public List<Model.User> GetSpecialUsers()
        {
            return repoUser.GetAll().Where(x => {return x.isSpecial == true; }).ToList();
        }

        public List<Model.User> GetAllUsers()
        {
            return repoUser.GetAll();
        }

        public void AddConference(Model.Conference conference)
        {
            repoConference.addConference(conference);
        }

        public void AddMessage(Model.Message message)
        {
            repoMessage.Add(message);
        }
        public void DeleteMessage(Model.Message message)
        {
            repoMessage.Delete(message);
        }
        public List<Model.Message> GetUserMessages(int userID)
        {
            return repoMessage.GetByUser(userID);
        }
        public bool addPaper(Model.Paper paper)
        {
            repoPaper.Add(paper);
            return true;
        }
        public void removePaper(int id)
        {
            repoPaper.Remove(id);
        }

        public void AddBid(Model.Participant bidder, int confId, int paper, int value)
        {
            List<Model.Paper> papers = repoPaper.GetByConference(confId);
            foreach (Model.Paper p in papers)
            {
                if (p.Id == paper)
                {
                    Model.Paper newP = p;
                    newP.AddBid(bidder, value);
                    repoPaper.Modify(paper, newP);
                }
            }
        }
        public void AddAvailableRoom(int confId, string roomName, int capacity, string street, string city, string postalCode, DateTime beginDate, DateTime endDate)
        {
            repoAvailableRoom.Add(confId, roomName, capacity, street, city, postalCode, beginDate, endDate);
        }
    }
}
