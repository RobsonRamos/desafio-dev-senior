using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MapLink.Domain;
using MapLink.Proxy.Config;
using MapLink.Proxy.Config.Mappers;
using MapLink.Proxy.Contracts;
using MapLink.Proxy.MapLinkRouteService;

namespace MapLink.Proxy
{
    public class MapLinkRouteCalculator : IRouteCalculator
    {
        private readonly IToken _token;
        private IMapLinkConfig _config;

        static MapLinkRouteCalculator()
        {
            Mapper.AddProfile(new RouteStopMapper());
            Mapper.AddProfile(new RouteMapper());
        }

        public MapLinkRouteCalculator(IToken token)
        {
            _token = token;
            _config = new MapLinkConfig();
        }

        public async Task<Route> CalcuteRouteAsync(IList<AddressSearch> addressSearches, RouteType routeType)
        {
            var routeStops = new List<RouteStop>();

            addressSearches.ToList().ForEach(x =>
            {
                var routeStop = Mapper.Map<AddressSearch, RouteStop>(x);
                var point = Mapper.Map<AddressSearch, Point>(x);
                routeStop.point = point;
                routeStops.Add(routeStop);
            });

            var options = _config.GetRouteOptions(routeType);

            using (var routeSoapClient = new RouteSoapClient())
            {
                var response = await routeSoapClient.getRouteAsync(routeStops.ToArray(), options, _token.Tokenvalue);

                if (response.Body.getRouteResult.routeTotals != null)
                {
                    var route = Mapper.Map<RouteTotals, Route>(response.Body.getRouteResult.routeTotals);                    
                    return route;
                }
            }
            return null;
        }
    }
}
