using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
#nullable disable

namespace Flight_Document_V1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private static Account account = new Account();
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost("login")]
        public async Task<ActionResult<Account>> Login(AuthDTO req)
        {
            try
            {
                var acc = await _authenticationService.CheckLogin(req);
                string token = _authenticationService.CreateToken(acc);

                var refreshToken = _authenticationService.GenerateRefreshToken();
                var setToken = _authenticationService.SetRefreshToken(refreshToken, Response);

                account = acc;
                account.RefreshToken = setToken.RefreshToken;
                account.TokenExpires = setToken.TokenExpires;

                TokenDTO dto = new TokenDTO();
                
                dto.Email = acc.Email;  
                dto.AccountName = acc.AccountName;
                dto.AccountID = acc.AccountID;
                dto.Token = token;
                dto.Role = acc.Role.RoleName;

                return Ok(dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("logout"), Authorize(Roles = "Admin, Staff, Pilot, Stewardess")]
        public ActionResult Logout(string token)
        {
            try
            {
                token = "";
                return Ok(token);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
