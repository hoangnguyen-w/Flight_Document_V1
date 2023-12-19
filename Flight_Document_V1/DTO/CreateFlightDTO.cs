#nullable disable
namespace Flight_Document_V1.DTO
{
    public class CreateFlightDTO
    {
        public string flightNo { get; set; }

        public string Router { get; set; }

        public DateTime DepartureDate { get; set; }

        public int locationID { get; set; }

        public int SecondLocationID { get; set; }
    }
}
