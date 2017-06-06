using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.View;
using System.Runtime.Remoting.Channels;
using System.Collections;
using System.Runtime.Remoting.Channels.Tcp;
using Services;
using System.Threading;

namespace Client
{
    static class StartClient
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BinaryServerFormatterSinkProvider servProv = new BinaryServerFormatterSinkProvider();
            servProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProv = new BinaryClientFormatterSinkProvider();

            IDictionary props = new Hashtable();
            props["port"] = 0;

            TcpChannel channel = new TcpChannel(props, clientProv, servProv);
            ChannelServices.RegisterChannel(channel, false);

            IServer server = (IServer)Activator.GetObject(typeof(IServer), "tcp://localhost:11111/Conferences");
            ClientController ctrl = new ClientController(server);

            Application.Run(new LoginForm(ctrl));
        }
    }
}
