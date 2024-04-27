using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Dtos
{
    public class LogInDTO
    {
        [Required]
        [StringLength(11),
            RegularExpression("^01[0125][0-9]{8}$"
            , ErrorMessage = "Invalid phone number or Password")]
        public string Phone { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }//don't forget the message about password constrains
    }
}
