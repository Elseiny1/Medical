using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Dtos
{
    public class PostDto
    {
        public string? PostId { get; set; } = null;

        [Required]
        public string? Text { get; set; } = null;

        [Required]
        public string? PostType { get; set; } = null;

        [Required]
        public string? Date { get; set; } = null;

        [Required]
        public string? Time { get; set; } = null;

        [Required]
        public string? Am_Pm { get; set; } = null;

        [Required]
        public string? DoctorPhone { get; set; } = null;
    }
}
