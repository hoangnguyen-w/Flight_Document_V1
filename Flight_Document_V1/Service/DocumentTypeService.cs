#nullable disable
using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.EntityFrameworkCore;

namespace Flight_Document_V1.Service
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private DocumentType documentType;
        private readonly FlightManagerContext _context;

        public DocumentTypeService(FlightManagerContext context)
        {
            _context = context;
        }

        public async Task<List<DocumentType>> GetAll()
        {

            var list = await _context.DocumentTypes.ToListAsync();
            return list;

        }

        public async Task<List<DocumentType>> GetByName(string name)
        {

            var list = await _context.DocumentTypes.Where(l => l.DocumentTypeName.Trim().ToLower().Contains(name.Trim().ToLower())).ToListAsync();
            return list;

        }

        public async Task<List<DocumentType>> FindByID(int id)
        {
            var acc = await _context.DocumentTypes.Where(l => l.DocumentTypeID == id).ToListAsync();
            return acc;
        }

        public async Task<DocumentType> FindIDReturnResult(int id)
        {
            var acc = await _context.DocumentTypes.FindAsync(id);
            return acc;
        }


        public async Task CreateDocumentType(DocumentTypeDTO documentTypeDTO)
        {

            documentType = new DocumentType();

            documentType.DocumentTypeName = documentTypeDTO.DocumentTypeName;

            _context.DocumentTypes.Add(documentType);
            await _context.SaveChangesAsync();

        }

        public async Task EditDocumentType(int id, DocumentTypeDTO documentTypeDTO)
        {

            var document = await _context.DocumentTypes.FirstOrDefaultAsync(l => l.DocumentTypeID == id);

            if(document == null)
            {
                return;
            }

            document.DocumentTypeName = documentTypeDTO.DocumentTypeName;

            _context.DocumentTypes.Update(document);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteDocumentType(int id)
        {
            var document = _context.DocumentTypes.FirstOrDefault(l => l.DocumentTypeID == id);
            _context.Remove(document);
            await _context.SaveChangesAsync();

        }
    }
}

