using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public Paper Paper { get; set; }
        public string Room { get; set; }
        public DateTime BegginHour { get; set; }
        public int Duration { get; set; }
        public DateTime Day { get; set; }

        //Constructor with parameters 
        public Reservation(int idReservation, Paper paper, string room, DateTime begginHour, int duration, DateTime day)
        {
            IdReservation = idReservation;
            Paper = paper;
            Room = room;
            BegginHour = begginHour;
            Duration = duration;
            Day = day;
        }

        public Reservation()
        {
        }

    }
}
