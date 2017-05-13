using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Participant
    {
        public Participant(int id, User user, Conference conference, bool isChair, bool isCochair, bool canBePCMember, bool isNormalUser)
        {
            Id = id;
            User = user;
            Conference = conference;
            IsChair = isChair;
            IsCochair = isCochair;
            CanBePCMember = canBePCMember;
            IsNormalUser = isNormalUser;
        }

        public int Id { get; set; }

        public User User { get; set; }
        
        public Conference Conference { get; set; }

        public bool IsChair { get; set; }

        public bool IsCochair { get; set; }

        public bool CanBePCMember { get; set; }

        public bool IsNormalUser { get; set; }
    }
}
