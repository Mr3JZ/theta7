using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Participant
    {
        public Participant(User user, int conferenceId, bool isChair, bool isCochair, bool canBePCMember, bool isNormalUser)
        {
            User = user;
            ConferenceId = conferenceId;
            IsChair = isChair;
            IsCochair = isCochair;
            CanBePCMember = canBePCMember;
            IsNormalUser = isNormalUser;
        }

        public Participant()
        {
        }

        public User User { get; set; }
        
        public int ConferenceId { get; set; }

        public bool IsChair { get; set; }

        public bool IsCochair { get; set; }

        public bool CanBePCMember { get; set; }

        public bool IsNormalUser { get; set; }
    }
}
