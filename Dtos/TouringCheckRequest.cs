using TouringChecker.Domain;

namespace TouringChecker.Dtos
{
    public class TouringCheckRequest
    {
        public Location? CurrentLocation { get; set; }
        public Location? Destination { get; set; }
    }
}
