using TelephoneCompanyApp.Domain.Entities;

namespace TelephoneCompanyApp.Domain.Repositories.PhoneNumbers
{
    public interface IPhoneNumberRepository
    {
        IEnumerable<PhoneNumber> GetAll(int? abonentId = null);
        void Add(PhoneNumber phoneNumber);
    }
}
