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
        [StringLength(11),
            RegularExpression("^(010|011|015|012)8[0-9]$"
            , ErrorMessage = "Invalid phone number")]
        public string Patient_Phone { get; set; }

        [Required]
        [MaxLength(250)
             , RegularExpression((@"[\p{L}\s]+$")
            , ErrorMessage = "Only charachtars or numbers or _ only")]
        public string Complaint { get; set; }

        [Required]
        [MaxLength(10)
            , RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/[0-9]{4}$"
            , ErrorMessage = "Date must be in the format dd/mm/yyyy")]
        public string Date { get; set; }

        [Required]
        [MaxLength(7)
            , RegularExpression(@"^[0-12]$"
            , ErrorMessage = "Only hours 0 to 12")]
        public string Time { get; set; }

        [Required]
        [MaxLength(2)
            , RegularExpression((@"^(PM|Pm|pm|AM|Am|am)$")
            , ErrorMessage = "Only Am or Pm allowed")]
        public string Am_Pm { get; set; }

        [Required]
        [MaxLength(35)
             , RegularExpression((@"[\p{L}\s]+$")
            , ErrorMessage = "Only charachtars or numbers or _ only")]
        public string Book_Type { get; set; }

        [Required]
        [Display(Name = "Recheck price")]
        [Range(typeof(double), "0", "999999")]
        public double price { get; set; }
    }
}
