using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Model;

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

        public void login(string username, string password)
        {
            User user = new User(username, password);
            server.Login(user, this);
            currentUser = user;

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
        public void register(string username, string password, string name, string affiliation, string email, string website, bool isSpecial)
        {
            User user = new User(-1, username, password, name, affiliation, email, isSpecial, website);
            server.Register(user);
        }

        public List<Model.Conference> getConferences()
        {
            return server.GetConferences();
        }

        public Model.Conference getConference(int id)
        {
            return server.GetConference(id);
        }

        
        public List<Review> getReviewsByPaper(int paperId)
        {
            return server.GetReviewsByPaper(paperId);
        }

        public void addReview(int paperId, Review r)
        {
            server.AddReview(paperId, r);
        }

        public void addParticipant(Participant p)
        {
            server.AddParticipant(p);
        }
        
    }
}
