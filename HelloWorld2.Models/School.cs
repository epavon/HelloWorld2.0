using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld2.Model
{
    public class School
    {
        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string GPA { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Degrees { get; set; }
    }
}
