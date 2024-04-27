using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.EF
{
    public class AuthModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; } = false;
        public string? Phone { get; set; }
        public string? Role { get; set; }
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
