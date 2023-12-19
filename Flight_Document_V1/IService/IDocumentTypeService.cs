using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;

namespace Flight_Document_V1.IService
{
    public interface IDocumentTypeService
    {
        Task<List<DocumentType>> GetAll();
        Task<List<DocumentType>> GetByName(string name);
        Task<List<DocumentType>> FindByID(int id);

        Task<DocumentType> FindIDReturnResult(int id);

        Task CreateDocumentType(DocumentTypeDTO documentTypeDTO);
        Task EditDocumentType(int id, DocumentTypeDTO documentTypeDTO);
        Task DeleteDocumentType(int id);
    }
}
