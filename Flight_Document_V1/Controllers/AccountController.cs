using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Document_V1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, Staff")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Account>>> GetAll()
        {
            try
            {
                var list = await _accountService.GetAll();

                if (list == null)
                {
                    return NotFound();
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByName/{name}")]
        public async Task<ActionResult<List<Account>>> GetByName(string name)
        {
            try
            {
                var list = await _accountService.GetByName(name);

                if (list == null)
                {
                    return NotFound();
                }

                return Ok(list);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetByRole/{id}")]
        public async Task<ActionResult<Account>> GetByRole(int id)
        {
            try
            {
                var list = await _accountService.GetByRole(id);

                if (list == null)
                {
                    return NotFound();
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<Account>> GetId(int id)
        {
            try
            {
                var list = await _accountService.FindByID(id);

                if (list == null)
                {
                    return NotFound();
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreatAccount(RegisterAccountDTO accDTO)
        {
            try
            {
                await _accountService.CreateAccount(accDTO);
                return Ok(accDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditAccount(int id, AccountDTO accDTO)
        {
            try
            {
                await _accountService.EditAccount(id, accDTO);
                return Ok(accDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("ChangeStatus/{id}")]
        public async Task<ActionResult> ChangeStatusAccount(int id)
        {
            try
            {
                var list = await _accountService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound();
                }

                await _accountService.ChangeStatusAccount(id);
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            try
            {
                var list = await _accountService.FindIDToResult(id);
                if(list == null)
                {
                    return NotFound();
                }

                await _accountService.DeleteAccount(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
