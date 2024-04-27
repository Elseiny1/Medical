using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Models
{
    public class Comment
    {
        [Key]
        public int Number { get; set; }

        [Required]
        [ForeignKey("Post")]
        public string PostId { get; set; }

        [Required]
        public string Comment_Text { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}
