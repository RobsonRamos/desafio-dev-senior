using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace MapLink.Domain
{
    public class AddressSearch
    {
        private Street _street;
        private HouseNumber _houseHouseNumber;
        private City _city;
        private ZipCode _zipCode;
        private Coordinate _coordinate;

        
        public AddressSearch(string streetName, int houseNumber, string cityName, string districtName, string zipCode = "")
        {
            _street = streetName;
            _houseHouseNumber = houseNumber;
            _city = new City(cityName, districtName);
            _zipCode = zipCode;
        }

        public string StreetName 
        {
            get { return _street.Name; }
        }

        public int HouseNumber
        {
            get { return _houseHouseNumber.Number; }
        }

        public string CityName
        {
            get { return _city.Name; }
        }

        public string DistrictName
        {
            get { return _city.DistrictName; }
        }

        public string Zip
        {
            get { return _zipCode.Code; }
        }

        public double Latitude
        {
            get { return _coordinate.Latitude; }
        }

        public double Longitude
        {
            get { return _coordinate.Longitude; }
        }

        public void SetCoordinate(Coordinate coodinate)
        {
            _coordinate = coodinate;
        }
    }
}
