using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;

namespace Flight_Document_V1.IService
{
    public interface IAuthenticationService
    {
        Task<Account> CheckLogin(AuthDTO account);


        //Task Register(RegisterAccountDTO account);

        string CreateToken(Account account);

        RefreshDTO GenerateRefreshToken();

        Account SetRefreshToken(RefreshDTO newRefreshToken, HttpResponse response);
    }
}
