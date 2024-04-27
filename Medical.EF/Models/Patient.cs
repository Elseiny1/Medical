using Medical.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Models
{
    public class Patient
    {
        [Key]
        [MaxLength(11)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(35)]
        public string FName { get; set; }

        [Required]
        [MaxLength(35)]
        public string LName { get; set; }

        [Required]
        [MaxLength(10)]
        public string BirthDate { get; set; }

        [Required]
        public bool IsMale { get; set; }

        public bool Heart { get; set; }

        public bool Diabetes { get; set; }

        public bool Pressure { get; set; }

        public virtual ICollection<Book> Books { get; } = new List<Book>();
    }
}
