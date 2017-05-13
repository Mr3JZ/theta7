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
        void NewParticipant(Conference c, Participant p);
        void NewPaper(Conference c, Paper p);
        void UpdatePaper(Paper p);
        void UpdateConference(Conference c);
        void NewPayment(Payment p);

    }
}
