using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Server
{
    public class ServerImplementation : MarshalByRefObject, IServer
    {
        //toate repo-urile...


        private readonly IDictionary<String, IClient> loggedClients;

        public List<Conference> GetConferences()
        {
            //return confRepo.getAll();
            throw new NotImplementedException();
        }

        public void Login(User u, IClient client)
        {
            //cauta in user repo User u si daca parola ii ok baga clientu in dictionar, altfel exceptie
            throw new NotImplementedException();
        }

        public void Logout(User u, IClient client)
        {
            //scoate clientu din dictionar, eventual validari
            throw new NotImplementedException();
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
