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
        private readonly ISSEntities2 _context;
        public RepoMessageDB(ISSEntities2 context)
        {
            _context = context;
        }
        public void Add(Message m)
        {
            
                MessagesC mess = new MessagesC();
                mess.MessageBody = m.MessageBody;
                mess.MessageId = m.MessageId;
                mess.UserId = m.UserId;

            _context.MessagesCs.Add(mess);
            _context.SaveChanges();
            
        }

        public void Delete(Message m)
        {

            
                var message = _context.MessagesCs.Find(m.MessageId);
            _context.MessagesCs.Remove(message);
            _context.SaveChanges();
            
        }

        public List<Message> GetByUser(int userId)
        {
            List<Message> all = new List<Message>();
            
                foreach (var m in _context.getMessagesUser(userId))
                {
                    Message mess = new Message(m.MessageId, m.MessageBody, userId);
                    all.Add(mess);
                }
            

            return all;
        }
    }
}
