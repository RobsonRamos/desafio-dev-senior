using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MapLink.Domain;
using MapLink.Proxy.MapLinkRouteService;

namespace MapLink.Proxy.Config.Mappers
{
    public class RouteStopMapper: Profile
    {
        public override string ProfileName
        {
            get { return "RouteStopMapper"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AddressSearch, RouteStop>()
                .ForMember(dest => dest.description, opt => opt.ResolveUsing(x => x.StreetName));

            Mapper.CreateMap<AddressSearch, Point>()
                .ForMember(dest => dest.x, opt => opt.ResolveUsing(x => x.Longitude));

            Mapper.CreateMap<AddressSearch, Point>()
                .ForMember(dest => dest.y, opt => opt.ResolveUsing(x => x.Latitude));

        }

    }
}
