using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Flight_Document_V1.Service
#nullable disable
{
    public class AuthenticationService : IAuthenticationService
    {
        private Account _account;
        private readonly FlightManagerContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationService(FlightManagerContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<Account> CheckLogin(AuthDTO account)
        {

            var acc = await _context.Accounts.Include(a => a.Role).FirstOrDefaultAsync(a => a.Email == account.Email);
            if (acc != null)
            {
                if (account.Password != acc.Password)
                {
                    throw new BadHttpRequestException("Wrong password!");
                }
            }
            else
            {
                throw new BadHttpRequestException("Check Your Email and Password!!!!");
            }
            return acc;
        }

        public string CreateToken(Account account)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.AccountName),
                new Claim(ClaimTypes.PostalCode, account.AccountID + ""),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.Role, account.Role.RoleName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenSecret").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: cred
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public RefreshDTO GenerateRefreshToken()
        {
            var refreshToken = new RefreshDTO
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddHours(1),
                Created = DateTime.Now
            };
            return refreshToken;
        }

        public Account SetRefreshToken(RefreshDTO newRefreshToken, HttpResponse response)
        {
            _account = new Account();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };
            response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            _account.RefreshToken = newRefreshToken.Token;
            _account.TokenCreated = newRefreshToken.Created;
            _account.TokenExpires = newRefreshToken.Expires;

            return _account;
        }
    }
}
