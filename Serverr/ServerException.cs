using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Server
{
    [Serializable]

    public class ServerException: Exception
    {
            public ServerException() { }

            public ServerException(SerializationInfo info, StreamingContext context) : base(info, context) { }

            public ServerException(string message): base(message) { }

            public ServerException(string message, Exception inner): base(message, inner) { }
    }
}
