using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Author
    {
        public Author(int idAuthor, string name, string affiliation)
        {
            idAuthor = idAuthor;
            Name = name;
            Affiliation = affiliation;
        }
        public int idAuthor { get; set; }
        public string Name { get; set; }
        public string Affiliation { get; set; }
    }
}
