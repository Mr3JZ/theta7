using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NamedVerdict
    {
        public string Name { get; set; }
        public Verdict Verdict { get; set; }

        public NamedVerdict(string n, Verdict v)
        {
            Name = n;
            Verdict = v;
        }
    }
}
