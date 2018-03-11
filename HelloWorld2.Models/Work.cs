using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld2.Model
{
    public class Work
    {
        public int WorkId { get; set; }
        public string WorkName { get; set; }
        public string Description { get; set; }
        public string WorkTitle { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
    }
}
