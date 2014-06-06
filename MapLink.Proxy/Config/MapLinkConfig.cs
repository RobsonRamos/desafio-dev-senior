using MapLink.Domain;
using MapLink.Proxy.MapLinkAddressFinderService;
using MapLink.Proxy.MapLinkRouteService;

namespace MapLink.Proxy.Config
{
    public class MapLinkConfig : IMapLinkConfig
    {
        public AddressOptions GetAddressOptions()
        {
            return new AddressOptions
            {
                usePhonetic = true,
                searchType = (int)AddressSearchType.SearchTheTextAnywhereTypedAddress,
                resultRange = new ResultRange()
                {
                    pageIndex = 1,
                    recordsPerPage = 1
                }
            };
        }

        public RouteOptions GetRouteOptions(RouteType type, string language = "", Vehicle vehicle = null)
        {
            var options = new RouteOptions
            {
                language = string.IsNullOrWhiteSpace(language) ? "portugues" : language,
                routeDetails = new RouteDetails
                {
                    descriptionType = (int)DescriptionRoute.UrbanRoute,
                    routeType = (int)type
                }
            };

            if (vehicle != null)
            {
                options.vehicle = vehicle;
            }
            else
            {
                options.vehicle = GetDefaultVehicle();
            }

            return options;
        }

        protected virtual Vehicle GetDefaultVehicle()
        {
            return new Vehicle
            {
                tankCapacity = 20,
                averageConsumption = 9,
                fuelPrice = 3,
                averageSpeed = 60,
                tollFeeCat = 2
            };
        }
    }
}
