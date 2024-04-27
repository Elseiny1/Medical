using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Models
{
    public class Post
    {
        [Key]
        public string PostId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string PostType { get; set; }

        [Required]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public string Am_Pm { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        public string DoctorPhone { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;

        public virtual ICollection<PostImage> Images { get; } = new List<PostImage>();

        public virtual ICollection<PostVedio> Vedios { get; } = new List<PostVedio>();

        public virtual ICollection<Comment> Comments { get; } = new List<Comment>();
    }
}
