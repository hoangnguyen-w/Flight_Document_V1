using Flight_Document_V1.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Document_V1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;
        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpPut("UploadFile")]
        public async Task<ActionResult> UploadFile(IFormFile file)
        {
            try
            {
                var result = await _settingService.UploadLogo(file);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("ChangeStatusCapcha")]
        public async Task<ActionResult> ChangeStatus()
        {
            try
            {
                await _settingService.ChangeStatusCapcha();
                return Ok("Thành Công");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
