using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Flight_Document_V1.Service
{
    public class GroupPermissionService : IGroupPermissionService
    {

        private GroupPermission groupPermission;
        private readonly FlightManagerContext _context;

        public GroupPermissionService(FlightManagerContext context)
        {
            _context = context;
        }

        public async Task<List<GroupPermission>> GetAll()
        {

            var list = await _context.GroupPermissions.ToListAsync();
            return list;

        }

        public async Task<List<GroupPermission>> FindByID(int id)
        {
            var acc = await _context.GroupPermissions.Where(l => l.GroupPermissionID == id).ToListAsync();
            return acc;
        }

        public async Task CreateGroupPermission(GroupPermissionDTO groupPermissionDTO)
        {

            groupPermission = new GroupPermission();

            groupPermission.StatusPermission = groupPermissionDTO.StatusPermission;
            groupPermission.GroupID = groupPermissionDTO.GroupID;
            groupPermission.AccountID = groupPermissionDTO.AccountID;

            _context.GroupPermissions.Add(groupPermission);
            await _context.SaveChangesAsync();

        }

        public async Task EditGroupPermission(int id, GroupPermissionDTO groupPermissionDTO)
        {

            var groupPermission = await _context.GroupPermissions.FirstOrDefaultAsync(l => l.GroupID == id);

            groupPermission.StatusPermission = groupPermissionDTO.StatusPermission;
            groupPermission.GroupID = groupPermissionDTO.GroupID;
            groupPermission.AccountID = groupPermissionDTO.AccountID;

            _context.GroupPermissions.Update(groupPermission);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteGroupPermission(int id)
        {
            var gr = _context.GroupPermissions.FirstOrDefault(l => l.GroupPermissionID == id);
            _context.Remove(gr);
            await _context.SaveChangesAsync();

        }
    }
}
