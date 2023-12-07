using System.ComponentModel.DataAnnotations;

namespace Flight_Document_V1.DTO
#nullable disable
{
    public class AccountDTO
    {
        public string AccountName { get; set; }

        [MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Input your Number")]
        public string Phone { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Enter Account Email")]
        [RegularExpression(@"^.*@vietjetair\.com$", ErrorMessage = "Email must have the domain @vietjetair.com")]
        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleID { get; set; } 

    }
}
