using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Dtos
{
    public class CommentDto
    {
        [Required]
        [ForeignKey("Post")]
        public string? PostId { get; set; } = null;

        [Required]
        public string? Comment_Text { get; set; } = null;
    }
}
