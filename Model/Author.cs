using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Author
    {
        public Author(string name, string affiliation)
        {
            Name = name;
            Affiliation = affiliation;
        }

        public string Name { get; set; }
        public string Affiliation { get; set; }
    }
}
