#nullable disable
namespace Flight_Document_V1.DTO
{
    public class RefreshDTO
    {
        public string Token { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        public DateTime Expires { get; set; }
    }
}
