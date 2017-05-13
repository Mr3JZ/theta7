using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class User
    {
        public User(int idUser, string username, string password, string name, string affiliation, string email, bool isSpecial, int id, string website)
        {
            idUser = idUser;
            Username = username;
            Password = password;
            Name = name;
            Affiliation = affiliation;
            Email = email;
            this.isSpecial = isSpecial;
            Id = id;
            Website = website;
        }
        public int idUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Affiliation { get; set; }
        public string Email { get; set; }
        public bool isSpecial { get; set; }
        public int Id { get; set; }
        public string Website { get; set; }
    }
}
