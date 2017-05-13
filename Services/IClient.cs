using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IClient
    {
        void updatedConference(Conference c);
        void updatedPaper(Paper p);
    }
}
