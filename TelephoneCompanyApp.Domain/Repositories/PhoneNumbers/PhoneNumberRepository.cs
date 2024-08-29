using Dapper;
using System.Data;
using TelephoneCompanyApp.Domain.Entities;

namespace TelephoneCompanyApp.Domain.Repositories.PhoneNumbers
{
    public class PhoneNumberRepository : IPhoneNumberRepository
    {
        private readonly IDbConnection _db;
        public PhoneNumberRepository(IDbConnection db)
        {
            _db = db;
            InitializeDataBase();
        }

        private void InitializeDataBase()
        {
            _db.Execute($@"
                CREATE TABLE IF NOT EXISTS {PhoneNumber.TABLE_NAME}(
                {nameof(PhoneNumber.Id)} INTEGER PRIMARY KEY,            
                {nameof(PhoneNumber.Phone)} NVARCHAR(100),
                {nameof(PhoneNumber.Telephone)} NVARCHAR(100),
                {nameof(PhoneNumber.AbonentId)} INTEGER NOT NULL,
                FOREIGN KEY (AbonentId) REFERENCES Abonent(Id));");
        }

        public IEnumerable<PhoneNumber> GetAll(int? abonentId = null)
        {
            var query = $"SELECT * FROM {PhoneNumber.TABLE_NAME}";
            if (abonentId.HasValue)
            {
                query += $" WHERE {nameof(PhoneNumber.AbonentId)} = @AbonentId";
            }

            return _db.Query<PhoneNumber>(query, new { AbonentId = abonentId });
        }
        public void Add(PhoneNumber phoneNumber)
        {
            _db.Execute($@"
                INSERT INTO {PhoneNumber.TABLE_NAME}
                ({nameof(phoneNumber.Phone)},
                {nameof(phoneNumber.Telephone)},
                {nameof(phoneNumber.AbonentId)})
                VALUES (@Phone, @Telephone, @AbonentId)", phoneNumber);
        }
    }
}
