using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HelloWorld2.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Author cannot be longer than 50 characters.")]
        public string Author { get; set; }

        public string Category { get; set; }

        public int Rating { get; set; }

        public virtual ICollection<string> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
