using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MapLink.Domain;
using MapLink.Proxy;
using MapLink.Proxy.Contracts;

namespace MapLink.Services
{
    public class RouteService : IRouteService
    {
        private ICoordinateFinder _coordinateFinder;
        private IRouteCalculator _routeCalculator;

        public RouteService(ICoordinateFinder coordinateFinder, IRouteCalculator routeCalculator)
        {
            _coordinateFinder = coordinateFinder;
            _routeCalculator = routeCalculator;
        }

        public async Task<Route> CalculateRouteAsync(IList<AddressSearch> addressSearches, RouteType routeType)
        {

            if (addressSearches == null || addressSearches.Count() == 0)
            {
                throw new ArgumentException("Address cannot be null or empty.");
            }

            var tasks = addressSearches.Select(async search =>
            {
                var coordinate = await _coordinateFinder.FindCoordinateAsync(search);

                search.SetCoordinate(coordinate);
            });

            await Task.WhenAll(tasks);

            var result = await _routeCalculator.CalcuteRouteAsync(addressSearches, routeType);

            return result;
        }
    }
}
