using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Model;
using Server;
namespace Client
{
    public class ClientController : MarshalByRefObject, IClient
    {
        private readonly IServer server;
        private User currentUser;

        public ClientController(IServer server)
        {
            this.server = server;
            this.currentUser = null;
        }

        public void updatedConference(Conference c)
        {
            throw new NotImplementedException();
        }

        public void updatedPaper(Paper p)
        {
            throw new NotImplementedException();
        }

        public bool login(string username, string password)
        {
            try
            {
                User user = new User(username, password);
                server.Login(user, this);
                currentUser = user;
                return true;
            } catch(ServerException err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }
        public void logout()
        {
            try
            {
                server.Logout(currentUser, this);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public bool register(string username, string password, string name, string affiliation, string email, string website, bool isSpecial)
        {
            try
            {
                User user = new User(-1, username, password, name, affiliation, email, isSpecial, website);
                server.Register(user);
                return true;
            } catch(ServerException err)
            {
                Console.WriteLine(err.Message);
                return false;
            }
        }
        public List<Model.Conference> getAllConferences()
        {
            return server.GetConferences();
        }
        public List<Model.Conference> getMyConferences() //daca am timp o voi face mai frumoasa; daca aveti timp, feel free and change it
        {
            List<Model.Conference> allConferences = getAllConferences();
            List<Model.Conference> myConferences = new List<Model.Conference>();
            foreach(Conference conference in allConferences)
            {
                foreach(Participant participant in conference.Participants)
                {
                    if(participant.User.Name.Equals(currentUser.Name))
                    {
                        myConferences.Add(conference);
                        break;
                    }
                }
            }
            return myConferences;
        }
        public string getMyRank(Conference conference)
        {
            foreach(Model.Participant participant in conference.Participants)
            {
                if(participant.User.Name.Equals(currentUser.Name))
                {
                    if (participant.IsChair)
                        return "IsChair";
                    if (participant.IsCochair)
                        return "IsCoChair";
                    else //(participant.IsNormalUser)
                        return "IsNormalUser";

                }
            }
            return "User not found in conference";
        }
        public List<Model.Participant> getSpecialParticipants(Conference conference)
        {
            List<Model.Participant> specialUsersList = new List<Model.Participant>();
            foreach(Model.Participant participant in conference.Participants)
            {
                if (participant.IsChair || participant.IsCochair)
                    specialUsersList.Add(participant);
            }
            return specialUsersList;
        }
    }
}
