using Flight_Document_V1.Entity;

namespace Flight_Document_V1.IService
{
    public interface IHistoryService
    {
        Task<List<History>> GetAll();
        Task<List<History>> FindByID(int id);

        Task<List<History>> FindByIDWithDocument(int id);
    }
}
