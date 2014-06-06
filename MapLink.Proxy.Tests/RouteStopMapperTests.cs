using AutoMapper;
using MapLink.Domain;
using MapLink.Proxy.Config.Mappers;
using MapLink.Proxy.MapLinkRouteService;
using NUnit.Framework;
using Point = MapLink.Proxy.MapLinkRouteService.Point;

namespace MapLink.Proxy.Tests
{
    [TestFixture]
    public class RouteStopMapperTests
    {
        private AddressSearch _search;

        [SetUp]
        public void SetUp()
        {
            _search = new AddressSearch("Avenida Nove de Julho", 100, "São Paulo", "SP", "01103-000");
        }

        [Test]
        public void Mapping_Street_To_Destination_Object()
        {
            var profile = new RouteStopMapper();
            Mapper.AddProfile(profile);

            var dest = Mapper.Map<AddressSearch, RouteStop>(_search);

            Assert.AreEqual(dest.description, _search.StreetName);
        }

        [Test]
        public void Mapping_Longitude_To_Destination_Object()
        {
            var profile = new RouteStopMapper();
            Mapper.AddProfile(profile);

            var dest = Mapper.Map<AddressSearch, Point>(_search);

            Assert.AreEqual(dest.y, _search.Longitude);
        }

        [Test]
        public void Mapping_Latitude_To_Destination_Object()
        {
            var profile = new RouteStopMapper();
            Mapper.AddProfile(profile);

            var dest = Mapper.Map<AddressSearch, Point>(_search);

            Assert.AreEqual(dest.x, _search.Latitude);
        }


    }
}
