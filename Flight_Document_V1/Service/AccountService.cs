using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.EntityFrameworkCore;

namespace Flight_Document_V1.Service
#nullable disable

{
    public class AccountService : IAccountService
    {
        private Account account;
        private readonly FlightManagerContext _context;
        public AccountService(FlightManagerContext context)
        {
            _context = context;
        }

        public async Task<List<Account>> GetAll()
        {

            var list = await _context.Accounts
                //.Include(a => a.Role)
                //.Include(a => a.GroupPermissions)
                //.Include(a => a.Settings)
                .ToListAsync();
            return list;

        }

        public async Task<List<Account>> GetByName(string name)
        {

            var list = await _context.Accounts.Where(p => p.AccountName.Trim().ToLower().Contains(name.Trim().ToLower())).ToListAsync();
            return list;

        }

        public async Task<List<Account>> GetByRole(int roleID)
        {

            var list = await _context.Accounts.Where(a => a.RoleID == roleID).ToListAsync();
            return list;

        }

        public async Task<List<Account>> FindByID(int id)
        {
            var acc = await _context.Accounts.Where(a => a.AccountID == id).ToListAsync();
            return acc;

            /*var acc = await _context.Accounts.Include(a => a.Role)
                                             .Include(a => a.GroupPermissions)
                                             .Where(a => a.AccountID == id).Select(b => new Account
                                             {
                                                 AccountID = b.AccountID,
                                                 AccountName = b.AccountName,
                                                 Email = b.Email,
                                                 Password = b.Password,
                                                 Phone = b.Phone,
                                                 Image = b.Image, 
                                                 StatusTerminate = b.StatusTerminate,
                                                 RoleID = b.RoleID,
                                                 GroupPermissions = b.GroupPermissions,
                                             }).ToListAsync();
            return acc;*/
        }

        public async Task CreateAccount(RegisterAccountDTO accDTO)
        {

            account = new Account();

            account.Email = accDTO.Email;
            account.Password = accDTO.Password;
            account.StatusTerminate = true;
            account.RoleID = accDTO.RoleID;

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

        }

        public async Task EditAccount(int id, AccountDTO accDTO)
        {

            var acc = await _context.Accounts.FirstOrDefaultAsync(p => p.AccountID == id);

            acc.AccountName = accDTO.AccountName;
            acc.Email = accDTO.Email;
            acc.Password = accDTO.Password;
            acc.Phone = accDTO.Phone;
            acc.Image = accDTO.Image;
            acc.RoleID = accDTO.RoleID;

            _context.Accounts.Update(acc);
            await _context.SaveChangesAsync();

        }

        public async Task ChangeStatusAccount(int id)
        {

            var acc = await _context.Accounts.FirstOrDefaultAsync(p => p.AccountID == id);

            if (acc.StatusTerminate)
            {
                acc.StatusTerminate = false;

                _context.Accounts.Update(acc);
                await _context.SaveChangesAsync();
            }
            else
            {
                acc.StatusTerminate = true;

                _context.Accounts.Update(acc);
                await _context.SaveChangesAsync();
            }

        }

        public async Task DeleteAccount(int id)
        {
            var acc = _context.Accounts.FirstOrDefault(p => p.AccountID == id);
            _context.Remove(acc);
            await _context.SaveChangesAsync();

        }
    }
}
