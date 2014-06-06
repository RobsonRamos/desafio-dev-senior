using MapLink.Domain;
using MapLink.Proxy.MapLinkAddressFinderService;
using MapLink.Proxy.MapLinkRouteService;

namespace MapLink.Proxy
{
    public interface IMapLinkConfig
    {
        AddressOptions GetAddressOptions();

        RouteOptions GetRouteOptions(RouteType type, string language = "", Vehicle vehicle = null);
    }
}