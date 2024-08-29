using AutoMapper;
using TelephoneCompanyApp.Domain.Entities;
using TelephoneCompanyApp.Mvc.Dto.Addresses;
using TelephoneCompanyApp.Mvc.Services.Abonents.Dto;

namespace TelephoneCompanyApp.Mvc.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Abonent, AbonentDto>();
            CreateMap<Address, AddressDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.StreetName));  
        }
    }
}
