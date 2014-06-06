using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MapLink.Domain;

namespace MapLink.API.Models
{
    public class AddressViewModel
    {
        public string StreetName { get; set; }
        public int HouseNumber      { get; set; }
        public string CityName      { get; set; }
        public string DistrictName  { get; set; }
        public string Zip           { get; set; }
    }
}