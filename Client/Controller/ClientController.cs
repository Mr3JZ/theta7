using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using Model;

namespace Client
{
    class ClientController: MarshalByRefObject, IClient
    {
        private readonly IServer server;
        private User currentUser;

        public ClientController(IServer server)
        {
            this.server = server;
            this.currentUser = null;
        }

        public void updatedConference(Conference c)
        {
            throw new NotImplementedException();
        }

        public void updatedPaper(Paper p)
        {
            throw new NotImplementedException();
        }
    }
}
