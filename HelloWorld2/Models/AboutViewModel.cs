using HelloWorld2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld2.Models
{
    public class AboutViewModel
    {
       
        public List<Work> WorkPlaces { get; set; }
        public List<School> Schools { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Creation> Creations { get; set; }
        public About AboutMe { get; set; }
        public Website MyWebsite { get; set; }
    }
}
