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
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        


        public Session(int idSession, List<Reservation> papers, Participant sessionChair, DateTime beginDate, DateTime endDate)
        {
       
            IdSession = idSession;
            Papers = papers;
            SessionChair = sessionChair;
            BeginDate = beginDate;
            EndDate = endDate;
        }
    }
}
