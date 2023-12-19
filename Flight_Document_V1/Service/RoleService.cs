using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.EntityFrameworkCore;

namespace Flight_Document_V1.Service
#nullable disable
{
    public class RoleService : IRoleService
    {
        private Role role;
        private readonly FlightManagerContext _context;
        public RoleService(FlightManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetAll()
        {

            var list = await _context.Roles.ToListAsync();
            return list;

        }

        public async Task<List<Role>> GetName(string name)
        {

            var list = await _context.Roles.Where(p => p.RoleName.Trim().ToLower().Contains(name.Trim().ToLower())).ToListAsync();
            return list;

        }

        public async Task<List<Role>> FindByID(int id)
        {
            var acc = await _context.Roles.Where(r => r.RoleID == id)
                                          .Select(r => new Role
                                             {
                                                 RoleID = r.RoleID,
                                                 RoleName = r.RoleName,
                                             }).ToListAsync();
            return acc;

        }

        public async Task CreateRole(RoleDTO roleDTO)
        {

            role = new Role();

            role.RoleName = roleDTO.RoleName;

            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

        }

        public async Task EditRole(int id, RoleDTO roleDTO)
        {

            var role = await _context.Roles.FirstOrDefaultAsync(p => p.RoleID == id);

            role.RoleName = roleDTO.RoleName;

            _context.Roles.Update(role);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteRole(int id)
        {
            var role = _context.Roles.FirstOrDefault(p => p.RoleID == id);
            _context.Remove(role);
            await _context.SaveChangesAsync();

        }

        public async Task<Role> FindIDToResult(int id)
        {
            var list = await _context.Roles.FindAsync(id);
            return list;
        }
    }
}
