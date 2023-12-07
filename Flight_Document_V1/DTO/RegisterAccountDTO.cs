using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Flight_Document_V1.DTO
{
    public class RegisterAccountDTO
    {
        [Required(ErrorMessage = "Enter Account Email")]
        [RegularExpression(@"^.*@vietjetair\.com$", ErrorMessage = "Email must have the domain @vietjetair.com")]
        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleID { get; set; }
    }
}
