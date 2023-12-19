using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Flight_Document_V1.Service
{
    public class FlightService : IFlightService
    {
        private Flight flight;
        private readonly FlightManagerContext _context;

        public FlightService(FlightManagerContext context)
        {
            _context = context;
        }

        public async Task CreateFlight(CreateFlightDTO flightDTO)
        {
            flight = new Flight();

            flight.FlightNo = flightDTO.flightNo;
            flight.Router = flightDTO.Router;
            flight.DepartureDate = flightDTO.DepartureDate;
            flight.LocationID = flightDTO.locationID;
            flight.SecondLocationID = flightDTO.SecondLocationID;

            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFlight(string id)
        {
            var loca = _context.Flights.FirstOrDefault(f => f.FlightNo == id);
            _context.Remove(loca);
            await _context.SaveChangesAsync();
        }

        public async Task EditFlight(string id, FlightDTO flightDTO)
        {
            var loca = await _context.Flights.FirstOrDefaultAsync(f => f.FlightNo == id);

            flight.Router = flightDTO.Router;
            flight.DepartureDate = flightDTO.DepartureDate;
            flight.LocationID = flightDTO.locationID;
            flight.SecondLocationID = flightDTO.SecondLocationID;

            _context.Flights.Update(loca);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Flight>> FindByID(string id)
        {
            var list = await _context.Flights.Where(f => f.FlightNo == id).ToListAsync();
            return list;
        }

        public async Task<Flight> FindIDToResult(string id)
        {
            var list = await _context.Flights.FindAsync(id);
            return list;
        }

        public async Task<List<Flight>> GetAll()
        {
            var result = await _context.Flights.ToListAsync();
            return result;
        }

    }
}
