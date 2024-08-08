using TelephoneCompanyApp.Domain.Entities;

namespace TelephoneCompanyApp.Domain.Repositories.Abonents
{
    public interface IAbonentRepository
    {
        IEnumerable<Abonent> GetAll(string? phoneNumber);
    }
}
