using AutoMapper;
using TelephoneCompanyApp.Domain.Repositories.Abonents;
using TelephoneCompanyApp.Domain.Repositories.Addresses;
using TelephoneCompanyApp.Domain.Repositories.PhoneNumbers;
using TelephoneCompanyApp.Domain.Repositories.Streets;
using TelephoneCompanyApp.Mvc.Dto.Addresses;
using TelephoneCompanyApp.Mvc.Dto.Phones;
using TelephoneCompanyApp.Mvc.Services.Abonents.Dto;

namespace TelephoneCompanyApp.Mvc.Services.Abonents
{
    public class AbonentService : IAbonentService
    {
        private readonly IAbonentRepository _repository;
        private readonly IAddressRepository _addressRepository;
        private readonly IStreetRepository _streetRepository;
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly IMapper _mapper;

        public AbonentService(IAbonentRepository repository, IAddressRepository addressRepository, IStreetRepository streetRepository, IPhoneNumberRepository phoneNumberRepository, IMapper mapper)
        {
            _repository = repository;
            _addressRepository = addressRepository;
            _streetRepository = streetRepository;
            _phoneNumberRepository = phoneNumberRepository;
            _mapper = mapper;
        }


        public IEnumerable<AbonentDto> GetAll()
        {
            var abonents = _repository.GetAll();
            var result = new List<AbonentDto>();

            foreach (var abonent in abonents)
            {
                //var dto = new AbonentDto()
                //{
                //    Id = abonent.Id,
                //    Name = abonent.Name,
                //    LastName = abonent.LastName,
                //    MiddleName = abonent.MiddleName,
                //};
                var dto = _mapper.Map<AbonentDto>(abonent);

                var address = _addressRepository.Get(abonent.Id);
                
                //dto.Address = new AddressDto()
                //{
                //    BuildingNumber = address.BuildingNumber,
                //    Name = address.StreetName,
                //};
                dto.Address = _mapper.Map<AddressDto>(address);


                var phoneNumbers = _phoneNumberRepository.GetAll(abonent.Id);
                dto.Phones = phoneNumbers.Select(p => new PhoneDto
                {
                    Telephone = p.Telephone,
                    Phone = p.Phone,
                });
                result.Add(dto);
            }
            return result;
        }
    }
}
