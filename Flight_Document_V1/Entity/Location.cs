using System.ComponentModel.DataAnnotations;

namespace Flight_Document_V1.Entity
#nullable disable
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        public string LocationName { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
