using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ConfException : Exception
    {
        public ConfException() : base() { }

        public ConfException(String msg) : base(msg) { }

        public ConfException(String msg, Exception ex) : base(msg, ex) { }
    }
}
