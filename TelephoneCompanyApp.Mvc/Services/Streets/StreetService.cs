using TelephoneCompanyApp.Domain.Repositories.Addresses;
using TelephoneCompanyApp.Domain.Repositories.Streets;
using TelephoneCompanyApp.Mvc.Services.Streets.Dto;

namespace TelephoneCompanyApp.Mvc.Services.Streets
{
    public class StreetService : IStreetService
    {
        private readonly IStreetRepository _streetRepository;
        private readonly IAddressRepository _addressRepository;

        public StreetService(IStreetRepository streetRepository, IAddressRepository addressRepository)
        {
            _streetRepository = streetRepository;
            _addressRepository = addressRepository;
        }

        public IEnumerable<StreetDto> GetAll()
        {
            var streets = _streetRepository.GetAll();
            var result = new List<StreetDto>();

            foreach (var street in streets)
            {
                var dto = new StreetDto()
                {
                    Name = street.Name,
                };

                var quantity = _addressRepository.GetAbonentQuanityt(street.Name);
                dto.AbonentsQuantity = quantity;
                result.Add(dto);
            }
            return result;
        }
    }
}
