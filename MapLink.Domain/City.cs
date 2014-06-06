using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLink.Domain
{
    public class City
    {
        private string _name;
        private District _district;

        public City(string cityName, string districtName)
        {
            if (string.IsNullOrWhiteSpace(cityName))
            {
                throw new ArgumentException("City Name is required.");
            }

            _name = cityName;
            _district = districtName;
        }

        public string Name
        {
            get { return _name; }
        }

        public string DistrictName
        {
            get { return _district.Name; }
        }

        public override string ToString()
        {
            return string.Format("City Name : {0}", _name);
        }
    }
}
