using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Application.Token
{
    public class Token
    {
        public string AccsessToken { get; set; }
        public DateTime Expiration { get; set; } // Token süresini takip ediyor
    }
}
