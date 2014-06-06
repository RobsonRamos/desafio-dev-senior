using AutoMapper;
using MapLink.Domain;
using MapLink.Proxy.Config.Mappers;
using MapLink.Proxy.MapLinkAddressFinderService;
using MapLink.Proxy.MapLinkRouteService;
using NUnit.Framework;

namespace MapLink.Proxy.Tests
{
    [TestFixture]
    public class RouteMapperTests
    {
        private Route _route;
        private RouteTotals _routeTotals;

        [SetUp]
        public void SetUp()
        {
            _routeTotals = new RouteTotals()
            {
                totalTime = "abcd",
                totalDistance = 200,
                totalfuelCost = 300,
                totalCost = 400
            };
        }

        [Test]
        public void Mapping_Total_Time_To_Destination_Object()
        {
            var routeProfile = new RouteMapper();

            Mapper.AddProfile(routeProfile);

            var dest = Mapper.Map<RouteTotals, Route>(_routeTotals);

            Assert.AreEqual(dest.TotalTime, _routeTotals.totalTime);
        }

        [Test]
        public void Mapping_Total_Distance_To_Destination_Object()
        {
            var routeProfile = new RouteMapper();

            Mapper.AddProfile(routeProfile);

            var dest = Mapper.Map<RouteTotals, Route>(_routeTotals);

            Assert.AreEqual(dest.TotalDistance, _routeTotals.totalDistance);
        }

        [Test]
        public void Mapping_Total_Fuel_Cost_To_Destination_Object()
        {
            var routeProfile = new RouteMapper();

            Mapper.AddProfile(routeProfile);

            var dest = Mapper.Map<RouteTotals, Route>(_routeTotals);

            Assert.AreEqual(dest.TotalFuelCost, _routeTotals.totalfuelCost);
        }

        [Test]
        public void Mapping_Total_Cost_To_Destination_Object()
        {
            var routeProfile = new RouteMapper();

            Mapper.AddProfile(routeProfile);

            var dest = Mapper.Map<RouteTotals, Route>(_routeTotals);

            Assert.AreEqual(dest.TotalCost, _routeTotals.totalCost);
        }
    }
}
