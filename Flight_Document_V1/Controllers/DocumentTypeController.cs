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
    public class DocumentTypeController : Controller
    {
        private readonly IDocumentTypeService _documentTypeService;

        public DocumentTypeController(IDocumentTypeService documentTypeService)
        {
            _documentTypeService = documentTypeService;
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<DocumentType>>> GetAll()
        {
            try
            {
                var list = await _documentTypeService.GetAll();

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
        public async Task<ActionResult<List<DocumentType>>> GetName(string name)
        {
            try
            {
                var list = await _documentTypeService.GetByName(name);

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
        public async Task<ActionResult<DocumentType>> GetId(int id)
        {
            try
            {
                var list = await _documentTypeService.FindByID(id);

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
        public async Task<ActionResult> CreatDocumentType(DocumentTypeDTO documentTypeDTO)
        {
            try
            {
                await _documentTypeService.CreateDocumentType(documentTypeDTO);
                return Ok(documentTypeDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        //[Authorize(Roles = "Admin, Staff")]
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> EditDocumentType(int id, DocumentTypeDTO documentTypeDTO)
        {
            try
            {
                await _documentTypeService.EditDocumentType(id, documentTypeDTO);
                return Ok(documentTypeDTO);
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
                var list = await _documentTypeService.FindByID(id);

                await _documentTypeService.DeleteDocumentType(id);

                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
