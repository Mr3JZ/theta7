using Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class StartServer
    {
        static void Main(string[] args)
        {
            Persistence.Repository.RepoAvailableRoomDB repoAR = new Persistence.Repository.RepoAvailableRoomDB();
            Persistence.Repository.RepoConference repoC = new Persistence.Repository.RepoConference();
            Persistence.Repository.RepoMessageDB repoM = new Persistence.Repository.RepoMessageDB();
            Persistence.Repository.RepoPaperDB repoPap = new Persistence.Repository.RepoPaperDB();
            Persistence.Repository.RepoParticipantDB repoPar = new Persistence.Repository.RepoParticipantDB();
            Persistence.Repository.RepoPayment repoPay = new Persistence.Repository.RepoPayment();
            Persistence.Repository.RepoUserDB repoU = new Persistence.Repository.RepoUserDB();
            Persistence.Repository.RepoSessionDB repoS = new Persistence.Repository.RepoSessionDB();

            BinaryServerFormatterSinkProvider servProv = new BinaryServerFormatterSinkProvider();
            servProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();
            IDictionary props = new Hashtable();

            props["port"] = 11111;
            TcpChannel channel = new TcpChannel(props, clientProv, servProv);
            ChannelServices.RegisterChannel(channel, false);

            var server = new ServerImplementation(repoU, repoAR, repoC, repoM, repoPap, repoPar, repoPay, repoS);

            RemotingServices.Marshal(server, "Conferences");

            Console.WriteLine("Server go");
            Console.ReadLine();
        }
    }
}
