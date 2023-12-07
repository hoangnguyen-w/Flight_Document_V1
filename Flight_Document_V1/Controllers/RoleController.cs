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
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Role>>> GetAll()
        {
            try
            {
                var list = await _roleService.GetAll();

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
        public async Task<ActionResult<List<Role>>> GetName(string name)
        {
            try
            {
                var list = await _roleService.GetName(name);

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
        public async Task<ActionResult<Role>> GetId(int id)
        {
            try
            {
                var list = await _roleService.FindByID(id);

                if(list == null)
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
        public async Task<ActionResult> CreatRole(RoleDTO roleDTO)
        {
            try
            {
                await _roleService.CreateRole(roleDTO);
                return Ok(roleDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditRole(int id, RoleDTO roleDTO)
        {
            try
            {
                await _roleService.EditRole(id, roleDTO);
                return Ok(roleDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            try
            {
                var list = await _roleService.FindByID(id);

                await _roleService.DeleteRole(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
