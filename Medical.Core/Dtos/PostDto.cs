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
        [Required]
        [Display(Name = "Doctor's Phone")]
        [StringLength(11),
           RegularExpression("^01[0125][0-9]{8}$"
           , ErrorMessage = "Invalid phone number")]
        public string DoctorPhone { get; set; }

        [Required]
        [Display(Name = "Text Box")]
        [MaxLength(2500)
            , RegularExpression((@"[\p{L}\s]+$")
            , ErrorMessage = "Only charachtars or numbers or _ only")]
        public string Text { get; set; } = null;

        [Required]
        [Display(Name ="Post Type")]
        [RegularExpression("^(text|image|video)$",
            ErrorMessage ="type should be text or image or video")]
        public string PostType { get; set; }

        [Required]
        [MaxLength(10)
            , RegularExpression(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/[0-9]{4}$"
            , ErrorMessage = "Date must be in the format dd/mm/yyyy")]
        public string Date { get; set; }

        [Required]
        [MaxLength(7)
            , RegularExpression((@"^([01]?[0-9]):([0-5][0-9])$")
            , ErrorMessage = "Only hours 0 to 12")]
        public string Time { get; set; }

        [Required]
        [MaxLength(2)
           , RegularExpression((@"^(PM|Pm|pm|AM|Am|am)$")
           , ErrorMessage = "Only Am or Pm allowed")]
        public string Am_Pm { get; set; } 

        
    }
}
