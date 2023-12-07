using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.EntityFrameworkCore;

namespace Flight_Document_V1.Service
#nullable disable
{
    public class LocationService : ILocationService
    {
        private Location location;
        private readonly FlightManagerContext _context;
        public LocationService(FlightManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> GetAll()
        {

            var list = await _context.Locations.ToListAsync();
            return list;

        }

        public async Task<List<Location>> GetByName(string name)
        {

            var list = await _context.Locations.Where(l => l.LocationName.Trim().ToLower().Contains(name.Trim().ToLower())).ToListAsync();
            return list;

        }

        public async Task<List<Location>> FindByID(int id)
        {
            var acc = await _context.Locations.Where(l => l.LocationID == id).ToListAsync();
            return acc;
        }

        public async Task CreateLocation(LocationDTO locationDTO)
        {

            location = new Location();

            location.LocationName = locationDTO.LocationName;   

            _context.Locations.Add(location);
            await _context.SaveChangesAsync();

        }

        public async Task EditLocation(int id, LocationDTO locationDTO)
        {

            var loca = await _context.Locations.FirstOrDefaultAsync(l => l.LocationID == id);

            loca.LocationName = locationDTO.LocationName;

            _context.Locations.Update(loca);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteLocation(int id)
        {
            var loca = _context.Locations.FirstOrDefault(l => l.LocationID == id);
            _context.Remove(loca);
            await _context.SaveChangesAsync();

        }
    }
}