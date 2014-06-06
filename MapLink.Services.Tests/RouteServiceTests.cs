using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapLink.Domain;
using MapLink.Proxy;
using MapLink.Proxy.Contracts;
using MapLink.Proxy.MapLinkAddressFinderService;
using Moq;
using NUnit.Core;
using NUnit.Framework;

namespace MapLink.Services.Tests
{
    [TestFixture]
    public class RouteServiceTests
    {
        private IRouteService _routeService;
        private Mock<ICoordinateFinder> _mockFinder;
        private Mock<IRouteCalculator> _mockRouteCalculator;

        [SetUp]
        public void SetUp()
        {
            _mockFinder = new Mock<ICoordinateFinder>();
            _mockRouteCalculator = new Mock<IRouteCalculator>();

            _routeService = new RouteService(_mockFinder.Object, _mockRouteCalculator.Object);
        }


        [Test]
        public void If_Not_Null_Object_Was_Passed_Should_Call_The_Coordinate_Finder()
        {
            var address = new AddressSearch("asd", 100, "asd", "asd", "123");

            var list = new List<AddressSearch>() { address };

            _routeService.CalculateRouteAsync(list, RouteType.DefaultRouteFaster);

            _mockFinder.Verify(x => x.FindCoordinateAsync(address));
        }

        [Test]
        public void If_Not_Null_Object_Was_Passed_Should_Call_The_Route_Calculator()
        {
            var address = new AddressSearch("asd", 100, "asd", "asd", "123");

            var list = new List<AddressSearch>() { address };

            _routeService.CalculateRouteAsync(list, RouteType.DefaultRouteFaster);

            _mockRouteCalculator.Verify(x => x.CalcuteRouteAsync(It.IsAny<IList<AddressSearch>>(), RouteType.DefaultRouteFaster) ,Times.Once());
        }

        [Test]
        public void If_Has_Only_One_Address_Should_Call_The_Finder_Only_Once()
        {
            var address = new AddressSearch("asd", 100, "asd", "asd", "123");

            var list = new List<AddressSearch>() { address };

            _routeService.CalculateRouteAsync(list, RouteType.DefaultRouteFaster);

            _mockFinder.Verify(x => x.FindCoordinateAsync(address), Times.Once);
        }

        [Test]
        public void If_Has_Only_Two_Addresses_Should_Call_The_Finder_Only_Teice()
        {
            var address1 = new AddressSearch("asd", 100, "asd", "asd", "123");
            var address2 = new AddressSearch("asd", 100, "asd", "asd", "123");

            var list = new List<AddressSearch>() { address1, address2 };

            _routeService.CalculateRouteAsync(list, RouteType.DefaultRouteFaster);

            _mockFinder.Verify(x => x.FindCoordinateAsync(It.IsAny<AddressSearch>()), Times.Exactly(2));
        }

        [Test]
        public async void Should_Set_Coordinates_For_A_Known_Address()
        {


            var routeService = new RouteService(new MapLinkCoordinateFinder(new MapLinkToken()), new MapLinkRouteCalculator(new MapLinkToken()));

            var address1 = new AddressSearch("Avenida Paulista", 1000, "São Paulo", "SP");
            var address2 = new AddressSearch("Avenida Paulista", 2000, "São Paulo", "SP");

            var list = new List<AddressSearch>() { address1, address2 };

            await routeService.CalculateRouteAsync(list, RouteType.DefaultRouteFaster);

            Assert.IsTrue(address1.Latitude != 0 && address1.Longitude != 0);
        }

        [Test]
        public async void Should_Calculate_The_Route_For_A_Known_Address()
        {


            var routeService = new RouteService(new MapLinkCoordinateFinder(new MapLinkToken()), new MapLinkRouteCalculator(new MapLinkToken()));

            var address1 = new AddressSearch("Avenida Paulista", 1000, "São Paulo", "SP");
            var address2 = new AddressSearch("Avenida Paulista", 2000, "São Paulo", "SP");

            var list = new List<AddressSearch>() { address1, address2 };

            var route = await routeService.CalculateRouteAsync(list, RouteType.DefaultRouteFaster);

            Assert.IsTrue(route.TotalCost > 0);
            Assert.IsTrue(route.TotalDistance > 0);
            Assert.IsTrue(route.TotalFuelCost > 0);
            Assert.IsTrue(route.TotalTime != string.Empty);
        }

        [Test]
        public async void Should_Calculate_The_Route_For_A_Known_Address_Avoiding_The_Traffic_()
        {


            var routeService = new RouteService(new MapLinkCoordinateFinder(new MapLinkToken()), new MapLinkRouteCalculator(new MapLinkToken()));

            var address1 = new AddressSearch("Avenida Paulista", 1000, "São Paulo", "SP");
            var address2 = new AddressSearch("Avenida Nove de Julho", 2000, "São Paulo", "SP");

            var list = new List<AddressSearch>() { address1, address2 };

            var route = await routeService.CalculateRouteAsync(list, RouteType.RouteAvoidingTraffic);

            Assert.IsTrue(route.TotalCost > 0);
            Assert.IsTrue(route.TotalDistance > 0);
            Assert.IsTrue(route.TotalFuelCost > 0);
            Assert.IsTrue(route.TotalTime != string.Empty);
        }


        [Test]
        public async void Should_Set_Coordinates_For_More_Than_One_Known_Address()
        {
            var routeService = new RouteService(new MapLinkCoordinateFinder(new MapLinkToken()), new MapLinkRouteCalculator(new MapLinkToken()));

            var address1 = new AddressSearch("Avenida Paulista", 1000, "São Paulo", "SP");

            var address2 = new AddressSearch("Rua vinte e cinco de janeiro", 180, "São Paulo", "SP");

            var list = new List<AddressSearch>() { address1, address2 };

            await routeService.CalculateRouteAsync(list, RouteType.DefaultRouteFaster);

            Assert.IsTrue(address1.Latitude != 0 && address1.Longitude != 0);

            Assert.IsTrue(address2.Latitude != 0 && address2.Longitude != 0);
        }

        [Test]
        [ExpectedException()]
        public async void Should_Throw_An_Exception_If_The_Token_Is_Invalid()
        {
            var mockToken = new Mock<IToken>();

            mockToken.Setup(x => x.Tokenvalue).Returns(string.Empty);

            _routeService = new RouteService(new MapLinkCoordinateFinder(mockToken.Object), _mockRouteCalculator.Object);

            var address1 = new AddressSearch("Avenida Paulista", 1000, "São Paulo", "SP");

            var list = new List<AddressSearch>() { address1 };

            await _routeService.CalculateRouteAsync(list, RouteType.DefaultRouteFaster);
        }

    }
}
