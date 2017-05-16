using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepoUserDB
    {
        public List<Model.User> GetAll()
        {
            List<Model.User> all = new List<Model.User>();
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                foreach(User u in context.Users)
                {
                    all.Add(new Model.User(u.UserId, u.Username, u.Password, u.Name, u.Affilliation, u.Email, u.canBePCMember, u.WebPage));
                }
            }

            return all;
        }

        public Model.User Find(int id)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                var u = context.Users.Find(id);
                return new Model.User(u.UserId, u.Username, u.Password, u.Name, u.Affilliation, u.Email, u.canBePCMember, u.WebPage);
            }
        }

        public void Add(Model.User u)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                User newser = new User(u.IdUser,u.Username,u.Name,u.Password,u.Email,u.Affiliation,u.Website,u.isSpecial);

                context.Users.Add(newser);
                context.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var context = new ISSEntities2(Util.ConnectionStringWithPassword.doIt()))
            {
                var u = context.Users.Find(id);
                context.Users.Remove(u);
                context.SaveChanges();
            }
        }
    }
}
