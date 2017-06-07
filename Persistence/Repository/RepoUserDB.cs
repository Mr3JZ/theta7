using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepoUserDB
    {
        private readonly ISSEntities2 _context;
        public RepoUserDB(ISSEntities2 context)
        {
            _context = context;
        }
        public List<Model.User> GetAll()
        {
            List<Model.User> all = new List<Model.User>();
                foreach(User u in _context.Users)
                {
                    all.Add(new Model.User(u.UserId, u.Username, u.Password, u.Name, u.Affilliation, u.Email, u.canBePCMember, u.WebPage));
                }

            return all;
        }

        public Model.User Find(int id)
        {
            
                var u = _context.Users.Find(id);
                return new Model.User(u.UserId, u.Username, u.Password, u.Name, u.Affilliation, u.Email, u.canBePCMember, u.WebPage);
            
        }

        public void Add(Model.User u)
        {
            
                User newser = new User();

                newser.Username = u.Username;
                newser.Name = u.Name;
                newser.Password = u.Password;
                newser.Email = u.Email;
                newser.Affilliation = u.Affiliation;
                newser.WebPage = u.Website;
                newser.canBePCMember = u.isSpecial;

            _context.Users.Add(newser);
            _context.SaveChanges();
            }
        

        public void Remove(int id)
        {
            
                var u = _context.Users.Find(id);
        _context.Users.Remove(u);
        _context.SaveChanges();
            
        }
    }
}
