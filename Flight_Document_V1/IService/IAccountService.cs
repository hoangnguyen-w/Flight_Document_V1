using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;

namespace Flight_Document_V1.IService
{
    public interface IAccountService
    {
        Task<List<Account>> GetAll();

        Task<List<Account>> GetByName(string name);

        Task<List<Account>> GetByRole(int roleID);

        Task<List<Account>> FindByID(int id);

        Task CreateAccount(RegisterAccountDTO accDTO);

        Task EditAccount(int id, AccountDTO accDTO);

        Task ChangeStatusAccount(int id);

        Task DeleteAccount(int id);
    }
}
