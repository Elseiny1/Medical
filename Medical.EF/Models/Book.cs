using Medical.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.EF.Models
{
    public class Book
    {
        [Key]
        public int Numbre { get; set; }

        [Required]
        [ForeignKey("Doctor")]
        [MaxLength(11)]
        public string Doctor_Phone { get; set; }

        [Required]
        [ForeignKey("Patient")]
        [MaxLength(11)]
        public string Patient_Phone { get; set; }

        [Required]
        [MaxLength(250)]
        public string Complaint { get; set; }

        [Required]
        [MaxLength(10)]
        public string Date { get; set; }

        [Required]
        [MaxLength(7)]
        public string Time { get; set; }

        [Required]
        [MaxLength(2)]
        public string Am_Pm { get; set; }

        [Required]
        [MaxLength(35)]
        public string Book_Type { get; set; }

        [Required]
        public double price { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;
    }
}
