using System.Collections.Generic;
using System.Threading.Tasks;
using MapLink.Domain;

namespace MapLink.Services
{
    public interface IRouteService
    {
        Task<Route> CalculateRouteAsync(IList<AddressSearch> addressSearches, RouteType routeType);
    }
}
