using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;

namespace Flight_Document_V1.IService
{
    public interface ILocationService
    {
        Task<List<Location>> GetAll();
        Task<List<Location>> GetByName(string name);
        Task<List<Location>> FindByID(int id);
        Task<Location> FindIDToResult(int id);
        Task CreateLocation(LocationDTO locationDTO);
        Task EditLocation(int id, LocationDTO locationDTO);
        Task DeleteLocation(int id);
    }
}
