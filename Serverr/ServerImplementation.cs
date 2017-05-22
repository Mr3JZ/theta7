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
        private Persistence.RepoSessionDB repoSession;
        

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

        public Model.Conference GetConference(int id)
        {
            var conf= repoConference.getConference(id);

            conf.Papers = repoPaper.GetByConference(conf.Id);
            conf.Participants = repoParticipant.GetByConference(conf.Id);
            conf.Sessions = repoSession.GetByConference(conf.Id);

            return conf;
        }

        public void Login(Model.User u, IClient client)
        {
            if (loggedClients.ContainsKey(u.Username) == true)
                throw new ServerException("User already logged in");

            List<Model.User> allUsers = repoUser.GetAll();
            foreach (Model.User user in allUsers)
                if (user.Username.Equals(u.Username) && user.Password.Equals(u.Password))
                {
                    loggedClients.Add(u.Username, client);
                    return;
                }

            throw new ServerException("Invalid user");
        }

        public void Logout(Model.User u, IClient client)
        {
            if(loggedClients[u.Username] == null)
                throw new NotImplementedException();//User is not logged in
            loggedClients.Remove(u.Username);
        }
        public void Register(Model.User user)
        {
            //Verifica daca user-ul exista in BD
            ///daca exista arunca exceptie
            repoUser.Add(user);
        }

        public void NewPaper(Model.Conference c, Model.Paper p)
        {
            throw new NotImplementedException();
        }

        public void AddParticipant(Participant p)
        {
            repoParticipant.Add(p);
        }

        public void NewPayment(Model.Payment p)
        {
            //adauga payment, notifica
            throw new NotImplementedException();
        }

        public void UpdateConference(Model.Conference c)
        {
            //updateaza o conferinta existenta, apelat la sesiuni noi
            throw new NotImplementedException();
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
    }
}
