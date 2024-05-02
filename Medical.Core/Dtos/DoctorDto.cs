using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Dtos
{
    public class DoctorDto
    {
        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(11),
            RegularExpression("^01[0125][0-9]{8}$"
            , ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = null;

        [Required]
        [Display (Name ="Full Name")]
        [MaxLength(50)
            ,RegularExpression((@"[\p{L}\s]+$")
            ,ErrorMessage ="Only charachtars or numbers or _ only")]
        public string Name { get; set; } = null;

        [Required]
        [Display(Name = "Password")]
        [MinLength(8)]
        public string Password { get; set; } = null;

        [Required]
        [Display(Name = "Confirm Password")]
        [MinLength(8)]
        public string CheckPassword { get; set; } = null;

        [Required]
        [Display(Name = "Governrate")]
        [MaxLength(50)
            ,RegularExpression((@"[\p{L}\s]+$")
            , ErrorMessage = "Only charachtars or numbers or _ only")]
        public string Governrate { get; set; } = null;

        [Required]
        [Display(Name = "City")]
        [MaxLength(50)
            , RegularExpression((@"[\p{L}\s]+$")
            , ErrorMessage = "Only charachtars or numbers or _ only")]
        public string City { get; set; } = null;

        [Required]
        [Display(Name = "Address")]
        [MaxLength(250)
            , RegularExpression((@"[\p{L}\s]+$")
            , ErrorMessage = "Only charachtars or numbers or _ only")]
        public string Adreess { get; set; } = null;

        [Required]
        [Display(Name = "Department")]
        [MaxLength(80)
            , RegularExpression((@"[\p{L}\s]+$")
            , ErrorMessage = "Only charachtars or numbers or _ only")]
        public string Department { get; set; } = null;

        [Required]
        [Display(Name = "Doctor Degree")]
        [MaxLength(50)
            , RegularExpression((@"[\p{L}\s]+$")
            , ErrorMessage = "Only charachtars or numbers or _ only")]
        public string ScienceDegree { get; set; } = null;

        [Required]
        [Display(Name = "Day from")]
        [MaxLength(20)
            , RegularExpression((@"^(Saturday|Sunday|Monday|Thursday|Tuesday|Wednesday|Friday)$")
            , ErrorMessage = "Only day of a week started with A capital")]
        public string FromDay { get; set; } = null;

        [Required]
        [Display(Name = "Day to")]
        [MaxLength(20)
            , RegularExpression((@"^(Saturday|Sunday|Monday|Thursday|Tuesday|Wednesday|Friday)$")
            , ErrorMessage = "Only day of a week started with A capital")]
        public string ToDay { get; set; } = null;

        [Required]
        [Display(Name = "Hour from")]
        [MaxLength(20)
            , RegularExpression((@"^([01]?[0-9]):([0-5][0-9]) ([AaPp][Mm])$")
            , ErrorMessage = "Invalid hour expretion")]
        public string FromHour { get; set; } = null;

        [Required]
        [Display(Name = "Hour to")]
        [MaxLength(20)
             , RegularExpression((@"^([01]?[0-9]):([0-5][0-9]) ([AaPp][Mm])$")
            , ErrorMessage = "Invalid hour expretion")]
        public string ToHour { get; set; } = null;

        [Required]
        [Display(Name = "Price")]
        [Range(typeof(double),"0","999999")]
        public double NewCheckPrie { get; set; }

        [Required]
        [Display(Name = "Recheck price")]
        [Range(typeof(double), "0", "999999")]
        public double ReCheckPrie { get; set; }

        [AllowNull]
       
        public IFormFile Image { get; set; }
    }
}
