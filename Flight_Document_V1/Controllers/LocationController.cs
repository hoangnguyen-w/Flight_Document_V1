using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Document_V1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class LocationController : Controller
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Location>>> GetAll()
        {
            try
            {
                var list = await _locationService.GetAll();

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
        public async Task<ActionResult<List<Location>>> GetName(string name)
        {
            try
            {
                var list = await _locationService.GetByName(name);

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
        public async Task<ActionResult<Location>> GetId(int id)
        {
            try
            {
                var list = await _locationService.FindByID(id);

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

        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        public async Task<ActionResult> CreatLocation(LocationDTO locationDTO)
        {
            try
            {
                await _locationService.CreateLocation(locationDTO);
                return Ok(locationDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditLocation(int id, LocationDTO locationDTO)
        {
            try
            {
                await _locationService.EditLocation(id, locationDTO);
                return Ok(locationDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteLocation(int id)
        {
            try
            {
                var list = await _locationService.FindByID(id);

                await _locationService.DeleteLocation(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
