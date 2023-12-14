

using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;

namespace Flight_Document_V1.IService
{
    public interface IGroupService
    {
        Task<List<Group>> GetAll();
        Task<List<Group>> GetByName(string name);
        Task<List<Group>> FindByID(int id);
        Task CreateGroup(GroupDTO groupDTO);
        Task EditGroup(int id, GroupDTO groupDTO);
        Task DeleteGroup(int id);
    }
}
