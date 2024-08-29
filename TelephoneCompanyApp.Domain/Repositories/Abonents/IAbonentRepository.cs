using TelephoneCompanyApp.Domain.Entities;

namespace TelephoneCompanyApp.Domain.Repositories.Abonents
{
    public interface IAbonentRepository
    {
        IEnumerable<Abonent> GetAll();
        void Add(Abonent abonent);
        int? GetIdOrDefault(string fio);
        Abonent GetById(int id);
        void Delete(int id);
    }
}
