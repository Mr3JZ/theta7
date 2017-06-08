using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AvailableRoom
    {
        public AvailableRoom(int confId, string roomName, int capacity, string street, string city, string postalCode, DateTime beginDate, DateTime endDate)
        {
            ConfId = confId;
            RoomName = roomName;
            Capacity = capacity;
            Street = street;
            City = city;
            PostalCode = postalCode;
            BeginDate = beginDate;
            EndDate = endDate;
        }

        //int confId, string roomName, int capacity, string street, string city, string postalCode, DateTime beginDate, DateTime endDate
        public int ConfId { get; set; }
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
