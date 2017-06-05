using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepoMessageDB
    {
        public void Add(Message m)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                MessagesC mess = new MessagesC();
                mess.MessageBody = m.MessageBody;
                mess.MessageId = m.MessageId;
                mess.UserId = m.UserId;

                context.MessagesCs.Add(mess);
                context.SaveChanges();
            }
        }

        public void Delete(Message m)
        {

            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                var message = context.MessagesCs.Find(m.MessageId);
                context.MessagesCs.Remove(message);
                context.SaveChanges();
            }
        }

        public List<Message> GetByUser(int userId)
        {
            List<Message> all = new List<Message>();

            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                foreach (var m in context.getMessagesUser(userId))
                {
                    Message mess = new Message(m.MessageId, m.MessageBody, userId);
                    all.Add(mess);
                }
            }

            return all;
        }
    }
}
