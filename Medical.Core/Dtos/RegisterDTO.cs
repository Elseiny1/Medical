using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Core.Dtos
{
    public class RegisterDTO
    {
        [Required, StringLength(50)]
        public string Phone { get; set; }

        [Required, StringLength(256)]
        public string Password { get; set; }

        [Required, StringLength(256)]
        public string CheckPassword { get; set; }

        public string? Message { get; set; }
    }
}
