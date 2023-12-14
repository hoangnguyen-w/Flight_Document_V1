using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Document_V1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupPermissionController : Controller
    {
        private readonly IGroupPermissionService _groupPermissionService;

        public GroupPermissionController(IGroupPermissionService groupPermissionService)
        {
            _groupPermissionService = groupPermissionService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<GroupPermission>>> GetAll()
        {
            try
            {
                var list = await _groupPermissionService.GetAll();

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
        public async Task<ActionResult<Group>> GetId(int id)
        {
            try
            {
                var list = await _groupPermissionService.FindByID(id);

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

        //[Authorize(Roles = "Admin, Staff")]
        [HttpPost("Create")]
        public async Task<ActionResult> CreateGroupPermission(GroupPermissionDTO groupPermissionDTO)
        {
            try
            {
                await _groupPermissionService.CreateGroupPermission(groupPermissionDTO);
                return Ok(groupPermissionDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[Authorize(Roles = "Admin, Staff")]
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditGroupPermission(int id, GroupPermissionDTO groupPermissionDTO)
        {
            try
            {
                await _groupPermissionService.EditGroupPermission(id, groupPermissionDTO);
                return Ok(groupPermissionDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[Authorize(Roles = "Admin, Staff")]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteDocumentType(int id)
        {
            try
            {
                var list = await _groupPermissionService.FindByID(id);

                await _groupPermissionService.DeleteGroupPermission(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
