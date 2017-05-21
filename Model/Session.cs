using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model
{
    [Serializable]
    public class Session
    {
        public int IdSession { get; set; }
        public List<Reservation> Papers { get; set; }
        public Participant SessionChair { get; set; }
        


        public Session(int idSession, List<Reservation> papers, Participant sessionChair)
        {
       
            IdSession = idSession;
            Papers = papers;
            SessionChair = sessionChair;
        }
    }
}
