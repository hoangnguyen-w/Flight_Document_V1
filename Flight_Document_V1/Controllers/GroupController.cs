using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Document_V1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Group>>> GetAll()
        {
            try
            {
                var list = await _groupService.GetAll();

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
        public async Task<ActionResult<List<Group>>> GetName(string name)
        {
            try
            {
                var list = await _groupService.GetByName(name);

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
                var list = await _groupService.FindByID(id);

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
        public async Task<ActionResult> CreateGroup(GroupDTO groupDTO)
        {
            try
            {
                await _groupService.CreateGroup(groupDTO);
                return Ok(groupDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[Authorize(Roles = "Admin, Staff")]
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditGroup(int id, GroupDTO groupDTO)
        {
            try
            {
                await _groupService.EditGroup(id, groupDTO);
                return Ok(groupDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[Authorize(Roles = "Admin, Staff")]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            try
            {
                var list = await _groupService.FindByID(id);

                await _groupService.DeleteGroup(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
