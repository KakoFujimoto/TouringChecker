namespace TouringChecker.Domain
{
    public class TouringRequest
    {
        public Location? CurrentLocation { get; init; }
        public Location? Destination { get; init; }
    }
}
