using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight_Document_V1.Entity
#nullable disable
{
    public class Group
    {
        [Key]
        public int GroupID { get; set; }


        [Required(ErrorMessage = "Enter Group Name")]
        [MaxLength(100)]
        public string GroupName { get; set; }

        public string Creator { get; set; }

        public DateTime CreateDateGroup { get; set; }

        public string Note { get; set; }

        [ForeignKey("Document")]
        public int? DocumentID { get; set; }
        public virtual Document Document { get; set; }

        public virtual ICollection<GroupPermission> GroupPermissions { get; set; }
    }
}
