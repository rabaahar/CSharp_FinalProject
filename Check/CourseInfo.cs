using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check
{
    public class CourseInfo
    {
        public int Id { get; set; }
        public string Course_Name { get; set; }
        public List<string> Students { get; set; } = new List<string>();
        public string? Languge { get; set; }    

        

    }
}
