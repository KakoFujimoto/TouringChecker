using TouringChecker.Domain;

namespace TouringChecker.Services
{
    public class IGeocodingService
    {
        ResolveLocation GetByCityName(string cityName);
    }
}
