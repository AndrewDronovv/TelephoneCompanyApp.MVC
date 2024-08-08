using TelephoneCompanyApp.Domain.Entities;

namespace TelephoneCompanyApp.Domain.Repositories.Streets
{
    public interface IStreetRepository
    {
        IEnumerable<Street> GetAll();
        void Add(Street street);
    }
}
