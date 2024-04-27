using Medical.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Models
{
    public class Doctor
    {
        [Key]
        [MaxLength(11)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(35)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Governrate { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(250)]
        public string Adreess { get; set; }

        [Required]
        [MaxLength(80)]
        public string Department { get; set; }

        [Required]
        [MaxLength(50)]
        public string ScienceDegree { get; set; }

        [Required]
        [MaxLength(20)]
        public string FromDay { get; set; }

        [Required]
        [MaxLength(20)]
        public string ToDay { get; set; }

        [Required]
        [MaxLength(20)]
        public string FromHour { get; set; }

        [Required]
        [MaxLength(20)]
        public string ToHour { get; set; }

        public double NewCheckPrie { get; set; }

        public double ReCheckPrie { get; set; }

        [AllowNull]
        public string ImageUrl { get; set; }

        public virtual ICollection<Post> Posts { get; } = new List<Post>();

        public virtual ICollection<Book> Books { get; } = new List<Book>();
    }
}
