using System.Threading.Tasks;
using AutoMapper;
using MapLink.Domain;
using MapLink.Proxy.Config;
using MapLink.Proxy.Config.Mappers;
using MapLink.Proxy.Contracts;
using MapLink.Proxy.MapLinkAddressFinderService;

namespace MapLink.Proxy
{
    public class MapLinkCoordinateFinder : ICoordinateFinder
    {
        private readonly IToken _token;
        private IMapLinkConfig _config;

        static MapLinkCoordinateFinder()
        {
            Mapper.AddProfile(new AddressMapper());
        }

        public MapLinkCoordinateFinder(IToken token)
        {
            _token = token;
            _config = new MapLinkConfig();
        }

        public async Task<Coordinate> FindCoordinateAsync(AddressSearch search)
        {
            using (var addressFinderSoapClient = new AddressFinderSoapClient())
            {
                
                var address = Mapper.Map<AddressSearch, Address>(search);
                
                var response = await addressFinderSoapClient.findAddressAsync(address, _config.GetAddressOptions(), _token.Tokenvalue);

                if (response.Body.findAddressResult.addressLocation.Length > 0)
                {
                    var point = response.Body.findAddressResult.addressLocation[0].point;
                    return new Coordinate(point.y, point.x);
                }
            }
            return await Task.FromResult(Coordinate.Empty());
        }
    }
}
