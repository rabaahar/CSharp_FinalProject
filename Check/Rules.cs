using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check
{
    public class Rules
    {
        public int Rule_Number { get; set; }
        public int Points { get; set; }
        public string ?File_Name { get; set; }
        public string ?Regular_Exp { get; set; }    // regular expression

        
    }
}
