using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Models
{
    public class PostVedio
    {
        [Required]
        [ForeignKey("Post")]
        public string PostId { get; set; }

        [Required]
        public string Vedio_Url { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}
