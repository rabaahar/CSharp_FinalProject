using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check
{
    public class CourseInfo
    {
        public string Id { get; set; }
        public string Course_name { get; set; }
        public string? Language { get; set; }
        public List<string> Students { get; set; } = new List<string>();
    }
}
