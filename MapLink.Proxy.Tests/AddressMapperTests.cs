using AutoMapper;
using MapLink.Domain;
using MapLink.Proxy.Config.Mappers;
using MapLink.Proxy.MapLinkAddressFinderService;
using NUnit.Framework;

namespace MapLink.Proxy.Tests
{
    [TestFixture]
    public class AddressMapperTests
    {
        private AddressSearch _search;
        private Address _address;

        [SetUp]
        public void SetUp()
        {
            _search = new AddressSearch("Avenida Nove de Julho", 100, "São Paulo", "SP", "01103-000");
        }

        [Test]
        public void Mapping_Street_To_Destination_Object()
        {
            var mapperProfile = new AddressMapper();
            Mapper.AddProfile(mapperProfile);

            var dest = Mapper.Map<AddressSearch, Address>(_search);

            Assert.AreEqual(dest.street, _search.StreetName);
        }

        [Test]
        public void Mapping_House_Number_To_Destination_Object()
        {
            var mapperProfile = new AddressMapper();
            Mapper.AddProfile(mapperProfile);

            var dest = Mapper.Map<AddressSearch, Address>(_search);

            Assert.AreEqual(dest.houseNumber, _search.HouseNumber.ToString());
        }

        [Test]
        public void Mapping_City_Name_To_Destination_Object()
        {
            var mapperProfile = new AddressMapper();
            Mapper.AddProfile(mapperProfile);

            var dest = Mapper.Map<AddressSearch, Address>(_search);

            Assert.AreEqual(dest.city.name, _search.CityName);
        }

        [Test]
        public void Mapping_District_Name_To_Destination_Object()
        {
            var mapperProfile = new AddressMapper();
            Mapper.AddProfile(mapperProfile);

            var dest = Mapper.Map<AddressSearch, Address>(_search);

            Assert.AreEqual(dest.city.state, _search.DistrictName);
        }

        [Test]
        public void Mapping_Zip_Code_To_Destination_Object()
        {
            var mapperProfile = new AddressMapper();
            Mapper.AddProfile(mapperProfile);

            var dest = Mapper.Map<AddressSearch, Address>(_search);
            
            Assert.AreEqual(dest.zip, _search.Zip);
        }
    }
}
