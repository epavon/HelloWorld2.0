using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld2.Model
{
    //
    // Project will consist of the posts associated with it, the name, description, and progress.
    // Things like design, implementation and such will be done in the posts for the project.
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Progress { get; set; }            // Summary of the progress made so far


    }
}
