using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace Flight_Document_V1.Entity
{
    public class Document
    {
        [Key]
        public int DocumentID { get; set; }


        [Required(ErrorMessage = "Enter Document Name")]
        [MaxLength(100)]
        public string DocumentName { get; set; }

        public float Version { get; set; }

        public string Note { get; set; }


        [Required]
        public string DocumentFile { get; set; }

        public DateTime CreateDateDocument { get; set; }

        public DateTime? UpdateDateDocument { get; set; }


        [ForeignKey("DocumentType")]
        public int DocumentTypeID { get; set; }
        public virtual DocumentType DocumentType { get; set; }


        [ForeignKey("Flight")]
        public string FlightNo { get; set; }
        public virtual Flight Flight { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public virtual ICollection<History> Histories { get; set; }
    }
}
