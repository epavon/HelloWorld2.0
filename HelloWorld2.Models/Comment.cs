using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld2.Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        [Required]
        [StringLength(15, ErrorMessage="Cannot be longer than 15 characters.")]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(150, ErrorMessage = "First name cannot be longer than 150 characters.")]
        public string Content { get; set; }

        public string Email { get; set; }
    }
}
