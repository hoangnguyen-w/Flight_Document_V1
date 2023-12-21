using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace Flight_Document_V1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly IDocumentService _documentService;
        public DocumentController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Document>>> GetAll()
        {
            try
            {
                var list = await _documentService.GetAll();

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
        public async Task<ActionResult<Document>> GetId(int id)
        {
            try
            {
                var list = await _documentService.FindByID(id);

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

        [HttpGet]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            try
            {
                var result = await _documentService.DownloadFileDocument(id);
                return File(result.Item1, result.Item2, result.Item3);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateDocument([FromForm] DocumentDTO documentDTO, IFormFile file)
        {
            try
            {
                await _documentService.CreateDocument(documentDTO, file);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditDocument(int id, IFormFile file)
        {
            try
            {
                var list = await _documentService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound();
                }
                await _documentService.EditDocument(id, file);
                return Ok();
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
                var list = await _documentService.FindIDToResult(id);
                if (list == null)
                {
                    return NotFound();
                }

                await _documentService.DeleteDocument(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
