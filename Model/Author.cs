using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Author
    {
        public Author(int IdAuthor, string name, string affiliation)
        {
            IdAuthor = idAuthor;
            Name = name;
            Affiliation = affiliation;
        }
        public int IdAuthor { get; set; }
        public string Name { get; set; }
        public string Affiliation { get; set; }
    }
}
