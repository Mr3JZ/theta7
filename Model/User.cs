using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class User
    {
        public User() { }
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.IdUser = -1;
            this.Name = "";
            this.Affiliation = "";
            this.Email = "";
            this.isSpecial = false;
            this.Website = "";
        }
        public User(int idUser, string username, string password, string name, string affiliation, string email, bool isSpecial, string website)
        {
            IdUser = idUser;
            Username = username;
            Password = password;
            Name = name;
            Affiliation = affiliation;
            Email = email;
            this.isSpecial = isSpecial;
            Website = website;
        }
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Affiliation { get; set; }
        public string Email { get; set; }
        public bool isSpecial { get; set; }
        public string Website { get; set; }
    }
}
