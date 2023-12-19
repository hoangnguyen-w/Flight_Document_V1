using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Flight_Document_V1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FlightController : Controller
    {

        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)

        {
            _flightService = flightService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Flight>>> GetAll()
        {
            try
            {
                var list = await _flightService.GetAll();

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
        public async Task<ActionResult<Flight>> GetId(string id)
        {
            try
            {
                var list = await _flightService.FindByID(id);

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

        [Authorize(Roles = "Admin, Staff")]
        [HttpPost("Create")]
        public async Task<ActionResult> CreateFlight(CreateFlightDTO createFlightDTO)
        {
            try
            {
                await _flightService.CreateFlight(createFlightDTO);
                return Ok(createFlightDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize(Roles = "Admin, Staff")]
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditFlight(string id, FlightDTO flightDTO)
        {
            try
            {
                var list = await _flightService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound();
                }

                await _flightService.EditFlight(id, flightDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [Authorize(Roles = "Admin, Staff")]
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteFlight(string id)
        {
            try
            {
                var list = await _flightService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound();
                }

                await _flightService.DeleteFlight(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
