using Flight_Document_V1.DTO;
using Flight_Document_V1.Entity;
using Flight_Document_V1.IService;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace Flight_Document_V1.Service
{
    public class SettingService : ISettingService
    {
        //private Setting setting;
        private readonly FlightManagerContext _context;

        public SettingService(FlightManagerContext context)
        {
            _context = context;
        }

        public async Task<string> UploadLogo(IFormFile file)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\logo");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\logo", filename);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                var list = _context.Settings.FirstOrDefault(s => s.Id == 1);
                list.Logo = exactpath;

                _context.Settings.Update(list);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return (ex.Message);
            }
            return filename;
        }
        public async Task ChangeStatusCapcha()
        {

            var tmp = await _context.Settings.FirstOrDefaultAsync(s => s.Id == 1);

            if (tmp.StatusCapcha)
            {
                tmp.StatusCapcha = false;

                _context.Settings.Update(tmp);
                await _context.SaveChangesAsync();
            }
            else
            {
                tmp.StatusCapcha = true;

                _context.Settings.Update(tmp);
                await _context.SaveChangesAsync();
            }

        }
    }
}
