using TelephoneCompanyApp.Domain.Entities;
using TelephoneCompanyApp.Domain.Repositories.Abonents;
using TelephoneCompanyApp.Domain.Repositories.Addresses;
using TelephoneCompanyApp.Domain.Repositories.Streets;

namespace TelephoneCompanyApp.Domain.Seed
{
    public class AddressSeed : BaseSeed
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IStreetRepository _streetRepository;
        private readonly IAbonentRepository _abonentRepository;
        public AddressSeed(IAddressRepository addressRepository, IStreetRepository streetRepository, IAbonentRepository abonentRepository)
        {
            _addressRepository = addressRepository;
            _streetRepository = streetRepository;
            _abonentRepository = abonentRepository;
        }

        public override void Initialize()
        {
            var addressItems = new List<CreateAddressSeedDTO>
            {
                new CreateAddressSeedDTO("Пушкинская","Максимов Алексей Иванович", "85Б"),
                new CreateAddressSeedDTO("Каштановая", "Филиппов Иннокентий Альфредович", "12"),
                new CreateAddressSeedDTO("Ленинская", "Афанасьев Максим Ильдарович", "09"),
            };
            foreach (var address in addressItems)
            {
                var streetId = _streetRepository.GetStreetIdOrDefault(address.Street);
                if (streetId == null)
                {
                    throw new Exception($"Улицы {address.Street} нет в БД");
                }

                var abonentId = _abonentRepository.GetIdOrDefault(address.AbonentFIO);
                if (abonentId == null)
                {
                    throw new Exception($"Абонент {address.AbonentFIO} нет в БД");
                }

                _addressRepository.Add(new Address(streetId.Value, address.BuildingNumber, abonentId.Value));
            }
        }
    }

    class CreateAddressSeedDTO
    {
        public string Street { get; set; }
        public string AbonentFIO { get; set; }
        public string BuildingNumber { get; set; }

        public CreateAddressSeedDTO(string street, string abonentFIO, string buildingNumber)
        {
            Street = street;
            AbonentFIO = abonentFIO;
            BuildingNumber = buildingNumber;
        }
    }
}
