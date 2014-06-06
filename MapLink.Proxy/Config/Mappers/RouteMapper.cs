using AutoMapper;
using MapLink.Domain;
using MapLink.Proxy.MapLinkRouteService;

namespace MapLink.Proxy.Config.Mappers
{
    public class RouteMapper : Profile
    {
        public override string ProfileName
        {
            get { return "RouteMapper"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<RouteTotals, Route>()
                .ForMember(dest => dest.TotalTime, opt => opt.ResolveUsing(x => x.totalTime));

            Mapper.CreateMap<RouteTotals, Route>()
                .ForMember(dest => dest.TotalDistance, opt => opt.ResolveUsing(x => x.totalDistance));

            Mapper.CreateMap<RouteTotals, Route>()
                .ForMember(dest => dest.TotalFuelCost, opt => opt.ResolveUsing(x => x.totalfuelCost));

            Mapper.CreateMap<RouteTotals, Route>()
                .ForMember(dest => dest.TotalCost, opt => opt.ResolveUsing(x => x.totalCost));
        }

    }
}
