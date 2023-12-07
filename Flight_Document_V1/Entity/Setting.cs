using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flight_Document_V1.Entity
#nullable disable
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }

        public string Logo { get; set; }

        public bool StatusCapcha { get; set; }

        [ForeignKey("Account")]
        public int AccountID { get; set; }
        public virtual Account Account { get; set; }
    }
}
