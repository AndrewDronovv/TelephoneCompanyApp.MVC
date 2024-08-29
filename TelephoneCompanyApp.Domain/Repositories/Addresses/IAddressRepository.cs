using TelephoneCompanyApp.Domain.Entities;

namespace TelephoneCompanyApp.Domain.Repositories.Addresses
{
    public interface IAddressRepository
    {
        IEnumerable<Address> GetAll();
        void Add(Address address);
        Address Get(int abonentId);
        int GetAbonentQuanityt(string streetName);
    }
}
