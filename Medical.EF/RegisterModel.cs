using Medical.EF.Data;
using System.ComponentModel.DataAnnotations;

namespace Medical.EF
{
    public class RegisterModel
    {
        [Required, StringLength(50)]
        public string Phone { get; set; }
        public string? Message { get; set; }
        public ApplicationIdentityUser? User { get; set; }
    }
}
