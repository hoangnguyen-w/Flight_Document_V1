using System.ComponentModel.DataAnnotations;

namespace Flight_Document_V1.Entity
#nullable disable
{
    public class DocumentType
    {
        [Key]
        public int DocumentTypeID { get; set; }

        [Required(ErrorMessage = "Input your Document Type ")]
        [MaxLength(100)]
        public string DocumentTypeName { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
