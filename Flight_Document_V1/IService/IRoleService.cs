using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;

namespace Flight_Document_V1.IService
{
    public interface IRoleService
    {
        Task<List<Role>> GetAll();
        Task<List<Role>> GetName(string name);
        Task<List<Role>> FindByID(int id);
        Task CreateRole(RoleDTO roleDTO);
        Task EditRole(int id, RoleDTO roleDTO);
        Task DeleteRole(int id);
    }
}
