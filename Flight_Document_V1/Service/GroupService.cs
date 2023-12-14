using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Flight_Document_V1.Service
{
    public class GroupService : IGroupService
    {
        private Group group;
        private readonly FlightManagerContext _context;

        public GroupService(FlightManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Group>> GetAll()
        {

            var list = await _context.Groups.ToListAsync();
            return list;

        }

        public async Task<List<Group>> GetByName(string name)
        {

            var list = await _context.Groups.Where(l => l.GroupName.Trim().ToLower().Contains(name.Trim().ToLower())).ToListAsync();
            return list;

        }

        public async Task<List<Group>> FindByID(int id)
        {
            var acc = await _context.Groups.Where(l => l.GroupID == id).ToListAsync();
            return acc;
        }

        // Fixx lại logic chỗ này
        public async Task CreateGroup(GroupDTO groupDTO)
        {

            group = new Group();

            group.GroupName = groupDTO.GroupName;
            group.Creator = groupDTO.Creator;
            group.CreateDateGroup = DateTime.Now;
            group.Note = groupDTO.Note;


            _context.Groups.Add(group);
            await _context.SaveChangesAsync();

        }

        public async Task EditGroup(int id, GroupDTO groupDTO)
        {

            var gr = await _context.Groups.FirstOrDefaultAsync(l => l.GroupID == id);

            gr.GroupName = groupDTO.GroupName;
            gr.Creator = groupDTO.Creator;
            gr.Note = groupDTO.Note;

            _context.Groups.Update(gr);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteGroup(int id)
        {
            var gr = _context.Groups.FirstOrDefault(l => l.GroupID == id);
            _context.Remove(gr);
            await _context.SaveChangesAsync();

        }
    }
}
