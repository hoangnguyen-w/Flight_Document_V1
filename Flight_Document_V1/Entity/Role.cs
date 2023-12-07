using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Flight_Document_V1.Entity
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        public string RoleName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }      
    }
}
