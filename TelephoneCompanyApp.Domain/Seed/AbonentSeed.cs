using TelephoneCompanyApp.Domain.Entities;
using TelephoneCompanyApp.Domain.Repositories.Abonents;

namespace TelephoneCompanyApp.Domain.Seed
{
    public class AbonentSeed : BaseSeed
    {
        private readonly IAbonentRepository _abonentRepository;

        public AbonentSeed(IAbonentRepository abonentRepository)
        {
            _abonentRepository = abonentRepository;
        }

        public override void Initialize()
        {
            var abonentsList = new List<Abonent>
            {
                new Abonent("Максимов", "Алексей", "Иванович"),
                new Abonent("Филиппов", "Иннокентий", "Альфредович"),
                new Abonent("Афанасьев", "Максим", "Ильдарович")
            };
            foreach (var abonent in abonentsList)
            {
                _abonentRepository.Add(new Abonent(abonent.LastName, abonent.Name,  abonent.MiddleName));
            }
        }
    }
}
