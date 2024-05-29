using Medical.EF.Models;
using Microsoft.AspNetCore.Identity;

namespace Medical.EF.Data
{
    public class ApplicationIdentityUser : IdentityUser
    {
        public List<RefreshToken>? RefreshTokens { get; set; }
    }
}
