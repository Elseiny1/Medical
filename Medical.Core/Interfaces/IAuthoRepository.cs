using Medical.Core.Dtos;
using Medical.EF;
using Medical.EF.Data;
using System.IdentityModel.Tokens.Jwt;

namespace Medical.Core.Interfaces
{
    public interface IAuthoRepository
    {
        public Task<AuthModel> RegisterAsync(RegisterDTO dto, string role);

        public Task<string> DeleteUser(ApplicationIdentityUser user);

        public Task<JwtSecurityToken> CreateJwtToken(ApplicationIdentityUser user);

        public Task<ApplicationIdentityUser> GetUser(string phone);

        public Task<AuthModel> GetTokenAsync(LogInDTO model);
    }
}
