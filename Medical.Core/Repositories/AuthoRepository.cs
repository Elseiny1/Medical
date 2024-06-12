using Medical.Core.Dtos;
using Medical.Core.Helpers;
using Medical.Core.Interfaces;
using Medical.EF.Data;
using Medical.EF.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;

namespace Medical.EF.Repositories
{
    public class AuthoRepository : IAuthoRepository
    {

        private readonly UserManager<ApplicationIdentityUser> _userManager;
        private readonly JWT _jWT;
        private readonly ApplicationDbContext _context;

        public AuthoRepository(UserManager<ApplicationIdentityUser> userManager,
                               IOptions<JWT> jWT,
                               ApplicationDbContext con
            )
        {
            _userManager = userManager;
            _jWT = jWT.Value;
        }

        public async Task<AuthModel> RegisterAsync(RegisterDTO dto, string role)
        {
            var email = dto.Phone + "@Gmail.Com";
            var emailfound = await _userManager.FindByEmailAsync(email.ToUpper());
            if (emailfound is not null)
            {
                return new AuthModel
                {
                    Message = "This Phone number is already in use"
                };
            }
            if (dto.Password != dto.CheckPassword)
            {
                return new AuthModel
                {
                    Message = "Check Password is not correct"
                };
            }
            var user = new ApplicationIdentityUser
            {
                PhoneNumber = dto.Phone,
                UserName = email,
                Email = email,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;

                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                return new AuthModel { Message = "Something went wrong in creating this account" };
            }
            await _userManager.AddToRoleAsync(user, role);

            var JwtSecurityToken = await CreateJwtToken(user);
            
            return new AuthModel
            {
                Phone = dto.Phone,
                //Expiration = JwtSecurityToken.ValidTo,
                IsAuthenticated = true,
                Role = role,
                Token = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken),
            };
        }

        public async Task<string> DeleteUser(ApplicationIdentityUser user)
        {
            await _userManager.DeleteAsync(user);
            return "ok";
        }

        public async Task<JwtSecurityToken> CreateJwtToken(ApplicationIdentityUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();
            foreach (var role in roles)
                roleClaims.Add(new Claim(ClaimTypes.Role, role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Prn,user.PhoneNumber)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecuritykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWT.key));
            var signingCredentioals = new SigningCredentials(symmetricSecuritykey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jWT.Issuer,
                audience: _jWT.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jWT.DurationInDays),
                signingCredentials: signingCredentioals);

            return jwtSecurityToken;
        }

        public async Task<ApplicationIdentityUser> GetUser(string phone)
        {
            var user = await _userManager.FindByEmailAsync(phone + "@Gmail.com".ToUpper());
            return user;
        }

        public async Task<AuthModel> GetTokenAsync(LogInDTO model)
        {
            var authModel = new AuthModel();
            var user = await _userManager.FindByEmailAsync(model.Phone + "@Gmail.com".ToUpper());
            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                authModel.Message = "Phone or Password is incorrect";
                return authModel;
            }

            var jwtSecurityToken = await CreateJwtToken(user);

            authModel.Phone = model.Phone;
            authModel.Role = _userManager.GetRolesAsync(user).ToString();
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            //authModel.Expiration = jwtSecurityToken.ValidTo;

            if(user.RefreshTokens.Any(t=>t.IsActive))
            {
                var activeRefreshToken = user.RefreshTokens.FirstOrDefault(t => t.IsActive);
                authModel.RefreshToken = activeRefreshToken.Token;
                authModel.RefreshTokenExpiration = activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authModel.RefreshToken = refreshToken.Token;
                authModel.RefreshTokenExpiration = refreshToken.ExpiresOn;
                user.RefreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }

            return authModel;
        }
        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];

            using var generator = new RNGCryptoServiceProvider();

            generator.GetBytes(randomNumber);

            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn = DateTime.UtcNow
            };
        }

        public async Task<AuthModel> RefreshTokenAsync(string token)
        {
            var authModel=new AuthModel();
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if(user ==null)
            {
                
                authModel.Message = "Invalid token";

                return authModel;
            }

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);
            if(!refreshToken.IsActive)
            {
                
                authModel.Message = "Inactive token";
                return authModel;
            }

            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.Single();
            
            //Revoke for each token use
            //generate new refreash token after revoke
            //generate new jwt to be retrun with user

            refreshToken.RevokedOn=DateTime.UtcNow;

            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);

            var jwtToken = await CreateJwtToken(user);
            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            authModel.Phone = user.PhoneNumber;
            authModel.Role = role;
            authModel.RefreshTokenExpiration = newRefreshToken.ExpiresOn;

            return authModel;
        }
        
        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == token));

            if(user == null)
                return false;

            var refreshToken = user.RefreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
                return false;

            refreshToken.RevokedOn = DateTime.UtcNow;

            await _userManager.UpdateAsync(user);

            return true;
        }

    }
}
