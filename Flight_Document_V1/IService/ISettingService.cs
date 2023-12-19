namespace Flight_Document_V1.IService
{
    public interface ISettingService
    {
        Task<string> UploadLogo(IFormFile file);

        Task ChangeStatusCapcha();
    }
}
