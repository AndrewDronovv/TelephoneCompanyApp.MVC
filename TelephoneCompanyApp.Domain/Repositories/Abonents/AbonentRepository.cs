using Dapper;
using System.Data;
using TelephoneCompanyApp.Domain.Entities;

namespace TelephoneCompanyApp.Domain.Repositories.Abonents
{
    public class AbonentRepository : IAbonentRepository
    {
        private readonly IDbConnection _db;

        public AbonentRepository(IDbConnection db)
        {
            _db = db;
        }

        private void InitializeDataBase()
        {
            _db.Execute($@"
                Create Table if not exists {Abonent.TABLE_NAME} (
                {nameof(Abonent.Id)} integer primary key, 
                {nameof(Abonent.Name)} text,
                {nameof(Abonent.LastName)} text,
                {nameof(Abonent.MiddleName)} text null)");
        }
        public IEnumerable<Abonent> GetAll(string? phoneNumber)
        {
            return _db.Query<Abonent>($"select * from {Abonent.TABLE_NAME}");
        }
    }
}
