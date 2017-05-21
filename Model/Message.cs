using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Message
    {
        public int MessageId { get; set; }
        public string MessageBody { get; set; }
        public int UserId { get; set; }

        public Message(int messageId, string messageBody, int userId)
        {
            MessageId = messageId;
            MessageBody = messageBody;
            UserId = userId;
        }

    }
}
