using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;

namespace Flight_Document_V1.IService
{
    public interface IFlightService
    {
        Task<List<Flight>> GetAll();
        Task<List<Flight>> FindByID(string id);
        Task<Flight> FindIDToResult(string id);
        Task CreateFlight(CreateFlightDTO flightDTO);
        Task EditFlight(string id, FlightDTO flightDTO);
        Task DeleteFlight(string id);
    }
}
