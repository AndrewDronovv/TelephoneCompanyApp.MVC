using TelephoneCompanyApp.Domain.Entities;
using TelephoneCompanyApp.Domain.Enums;
using TelephoneCompanyApp.Domain.Repositories.Abonents;
using TelephoneCompanyApp.Domain.Repositories.PhoneNumbers;

namespace TelephoneCompanyApp.Domain.Seed
{
    public class PhoneNumberSeed : BaseSeed
    {
        private readonly IPhoneNumberRepository _phoneNumberRepository;
        private readonly IAbonentRepository _abonentRepository;

        public PhoneNumberSeed(IPhoneNumberRepository phoneNumbersRepository, IAbonentRepository abonentRepository)
        {
            _phoneNumberRepository = phoneNumbersRepository;
            _abonentRepository = abonentRepository;
        }

        public override void Initialize()
        {
            var phoneNumberItems = new List<CreatePhoneNumberSeedDTO>
            {
                new CreatePhoneNumberSeedDTO("89773251150", Telephone.Cell, "Максимов Алексей Иванович"),
                new CreatePhoneNumberSeedDTO("84951452277", Telephone.Home, "Филиппов Иннокентий Альфредович"),
                new CreatePhoneNumberSeedDTO("88885004020", Telephone.Work, "Афанасьев Максим Ильдарович")
            };
            foreach (var phoneNumber in phoneNumberItems)
            {
                var abonentId = _abonentRepository.GetIdOrDefault(phoneNumber.AbonentFIO);
                if (abonentId == null)
                {
                    throw new Exception($"Абонент {phoneNumber.AbonentFIO} нет в БД");
                }

                _phoneNumberRepository.Add(new PhoneNumber(phoneNumber.Phone, phoneNumber.Telephone, abonentId.Value));
            }
        }
    }

    class CreatePhoneNumberSeedDTO
    {
        public string Phone { get; set; }
        public Telephone Telephone { get; set; }
        public string AbonentFIO { get; set; }

        public CreatePhoneNumberSeedDTO(string phone, Telephone telephone, string abonentFIO)
        {
            Phone = phone;
            Telephone = telephone;
            AbonentFIO = abonentFIO;
        }
    }
}
