using System.ComponentModel.DataAnnotations;
#nullable disable

namespace Flight_Document_V1.Entity
{
    public class History
    {
        [Key]
        public int HistoryID { get; set; }
        public DateTime HistoryDate { get; set; }

        public string DocumentHistory { get; set; }
        public int DocumentID { get; set; }
        public virtual Document Document { get; set; }
    }
}
