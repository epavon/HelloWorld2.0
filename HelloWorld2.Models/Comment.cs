using System;
using System.ComponentModel.DataAnnotations;

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

        public string DisplayContent
        {
            get { return Content.Replace("\r\n", "<br />"); }
        }

        public string Email { get; set; }
    }
}
