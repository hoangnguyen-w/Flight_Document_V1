using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Flight_Document_V1.Service
{
    public class HistoryService : IHistoryService
    {
        private readonly FlightManagerContext _context;
        public HistoryService(FlightManagerContext context)
        {
            _context = context;
        }
        public async Task<List<History>> FindByID(int id)
        {
            var list = await _context.Histories.Where(l => l.HistoryID == id).ToListAsync();
            return list;
        }

        public async Task<List<History>> GetAll()
        {
            var list = await _context.Histories.ToListAsync();
            return list;
        }

        public async Task<List<History>> FindByIDWithDocument(int id)
        {
            var list = await _context.Histories.Where(l => l.DocumentID == id).ToListAsync();
            return list;
        }

    }
}
