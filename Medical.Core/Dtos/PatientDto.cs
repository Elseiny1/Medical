using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Dtos
{
    public class PatientDto
    {
        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(11),
            RegularExpression("^01[0125][0-9]{8}$"
            , ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = null;

        [Required]
        [Display(Name ="Password")]
        [MinLength(8)]
        public string Password { get; set; } = null;

        [Required]
        [Display(Name ="Confirm Password")]
        [MinLength(8)]
        public string CheckPassword { get; set; } = null;

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(50)
            , RegularExpression((@"^[\u0621-\u064A\u0660-\u0669 ]+$")
            , ErrorMessage = "Only charachtars or numbers or _ only")]
        public string FName { get; set; } = null;

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50)
           , RegularExpression((@"^[\u0621-\u064A\u0660-\u0669 ]+$")
           , ErrorMessage = "Only charachtars or numbers or _ only")]
        public string LName { get; set; } = null;

        [Required]
        [MaxLength(10)]
        public string BirthDate { get; set; } = null;

        [Required]
        public bool IsMale { get; set; }

        [Required]
        public bool Heart { get; set; }

        [Required]
        public bool Diabetes { get; set; }

        [Required]
        public bool Pressure { get; set; }
    }
}
