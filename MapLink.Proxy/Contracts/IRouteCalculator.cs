using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLink.Domain;

namespace MapLink.Proxy.Contracts
{
    public interface IRouteCalculator
    {
        Task<Route> CalcuteRouteAsync(IList<AddressSearch> addressSearches, RouteType routeType);
    }
}
