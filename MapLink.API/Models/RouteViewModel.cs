using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Http;
using MapLink.Domain;

namespace MapLink.API.Models
{
    public class RouteViewModel
    {
        [Required]
        public IList<AddressSearch> AddressSearch { get; set; }
        
        [Required]
        public RouteType RouteType { get; set; }
    }
}