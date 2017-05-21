using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Persistence.Repository;
namespace Server
{
    public class ServerImplementation : MarshalByRefObject, IServer
    {
        //toate repo-urile...
        private RepoUserDB repoUser;

        private readonly IDictionary<String, IClient> loggedClients;

        public ServerImplementation(RepoUserDB repoUser)
        {
            this.repoUser = repoUser;
        }
        public List<Conference> GetConferences()
        {
            //return confRepo.getAll();
            throw new NotImplementedException();
        }

        public void Login(User u, IClient client)
        {
            if (loggedClients.ContainsKey(u.Username) == true)
                throw new NotImplementedException();//User already logged in

            List<Model.User> allUsers = repoUser.GetAll();
            foreach (Model.User user in allUsers)
                if (user.Username.Equals(u.Username) && user.Password.Equals(u.Password))
                {
                    loggedClients.Add(u.Username, client);
                    return;
                }

            throw new NotImplementedException();//Invalid user
        }

        public void Logout(User u, IClient client)
        {
            if(loggedClients[u.Username] == null)
                throw new NotImplementedException();//User is not logged in
            loggedClients.Remove(u.Username);
        }

        public void NewPaper(Conference c, Paper p)
        {
            //adauga paper nou in repo, eventual notifica
            throw new NotImplementedException();
        }

        public void NewParticipant(Conference c, Participant p)
        {
            //adauga participant nou, eventual notifica
            throw new NotImplementedException();
        }

        public void NewPayment(Payment p)
        {
            //adauga payment, notifica
            throw new NotImplementedException();
        }

        public void UpdateConference(Conference c)
        {
            //updateaza o conferinta existenta, apelat la sesiuni noi
            throw new NotImplementedException();
        }

        public void UpdatePaper(Paper p)
        {
            //updateaza o lucrare, eventual notifica 
            throw new NotImplementedException();
        }
    }
}
