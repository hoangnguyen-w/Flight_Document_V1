using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight_Document_V1.Entity
#nullable disable
{
    public class GroupPermission
    {
        [Key]
        public int GroupPermissionID { get; set; }

        public int StatusPermission { get; set; }


        [ForeignKey("Group")]
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }
        public virtual Account Account { get; set; }
    }
}
