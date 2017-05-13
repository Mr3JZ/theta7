using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Participant
    {
        //user
        //conference
        public bool IsChair { get; set; }

        public bool IsCochair { get; set; }

        public bool isPCMember { get; set; }

        public bool isNormalUser { get; set; }
    }
}
