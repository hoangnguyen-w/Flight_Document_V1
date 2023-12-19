using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;

namespace Flight_Document_V1.IService
{
    public interface IGroupPermissionService
    {
        Task<List<GroupPermission>> GetAll();
        Task<List<GroupPermission>> FindByID(int id);
        Task<GroupPermission> FindIDToResult(int id);
        Task CreateGroupPermission(GroupPermissionDTO groupPermissionDTO);
        Task EditGroupPermission(int id, GroupPermissionDTO groupPermissionDTO);
        Task DeleteGroupPermission(int id);
    }
}
