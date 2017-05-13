using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model
{
    public class Session
    {
        public int IdSession { get; set; }
        public List<Reservation> Papers { get; set; }
        public Participant SessionChair { get; set; }
        public DateTime BegginDate { get; set; }
        public DateTime EndDate { get; set; }
        


        public Session(int idSession, List<Reservation> papers, Participant sessionChair, DateTime begginDate, DateTime endDate)
        {
       
            IdSession = idSession;
            Papers = papers;
            SessionChair = sessionChair;
            BegginDate = begginDate;
            EndDate = endDate;
        }
    }
}
