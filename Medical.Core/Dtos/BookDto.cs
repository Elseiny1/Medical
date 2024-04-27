using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Dtos
{
    public class BookDto
    {
        [Required]
        [StringLength(11),
            RegularExpression("^(010|011|015|012)8[0-9]$"
            , ErrorMessage = "Invalid phone number")]
        public string Doctor_Phone { get; set; }

        [Required]
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
    }
}
