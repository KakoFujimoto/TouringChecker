using TouringChecker.Domain;

namespace TouringChecker.Services
{
    public interface IGeocodingService
    {
        ResolvedLocation GetByCityName(string cityName);
    }
}
