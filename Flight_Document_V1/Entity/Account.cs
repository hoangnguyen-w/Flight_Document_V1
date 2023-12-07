using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Flight_Document_V1.Entity
{
    public class Account
    {
        [Key]
        public int AccountID { get; set; }


        [MaxLength(100)]
        public string AccountName { get; set; }


        [MaxLength(200)]
        [Required(ErrorMessage = "Enter Account Email")]
        [RegularExpression(@"^.*@vietjetair\.com$", ErrorMessage = "Email must have the domain @vietjetair.com")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter Password")]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [MaxLength(20)]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Input your Number")]
        public string Phone { get; set; }

        public string Image { get; set; }

        public bool StatusTerminate { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }


        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }

        public virtual ICollection<Setting> Settings { get; set; }


        //JWT authentication
        public string RefreshToken { get; set; }
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}
