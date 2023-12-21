using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;

namespace Flight_Document_V1.IService
{
    public interface IDocumentService
    {
        Task<List<Document>> GetAll();
        Task<List<Document>> FindByID(int id);
        Task<Document> FindIDToResult(int id);
        
        Task CreateDocument(DocumentDTO documentDTO, IFormFile file);
        Task<(byte[], string, string)> DownloadFileDocument(int id);
        Task EditDocument(int id, IFormFile file);
        Task DeleteDocument(int id);
    }
}
