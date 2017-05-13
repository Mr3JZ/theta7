using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IServer
    {
        void Login(User u, IClient client);
        void Logout(User u, IClient client);
        List<Conference> GetConferences();
        void AddParticipant(Conference c, Participant p);
        void AddPaper(Conference c, Paper l);

    }
}
