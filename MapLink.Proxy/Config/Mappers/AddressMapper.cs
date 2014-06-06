using AutoMapper;
using MapLink.Domain;

namespace MapLink.Proxy.Config.Mappers
{
    public class AddressMapper : Profile
    {
        public override string ProfileName
        {
            get { return "AddressMapper"; }
        }

        protected override void Configure()
        {

            Mapper.CreateMap<AddressSearch, MapLinkAddressFinderService.Address>()
                .ForMember(dest => dest.street, opt => opt.ResolveUsing(x => x.StreetName));

            Mapper.CreateMap<AddressSearch, MapLinkAddressFinderService.Address>()
                .ForMember(dest => dest.houseNumber, opt => opt.ResolveUsing(x => x.HouseNumber));

            Mapper.CreateMap<AddressSearch, MapLinkAddressFinderService.Address>()
                .ForMember(dest => dest.city, opt => opt.ResolveUsing(x => 
                    new  MapLinkAddressFinderService.City(){ name = x.CityName, state = x.DistrictName}));

            Mapper.CreateMap<AddressSearch, MapLinkAddressFinderService.Address>()
                .ForMember(dest => dest.district, opt => opt.ResolveUsing(x => x.DistrictName));

            Mapper.CreateMap<AddressSearch, MapLinkAddressFinderService.Address>()
                .ForMember(dest => dest.zip, opt => opt.ResolveUsing(x => x.Zip));

        }
    }
}
