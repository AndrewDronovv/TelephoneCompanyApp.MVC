using Dapper;
using System.Data;
using TelephoneCompanyApp.Domain.Entities;

namespace TelephoneCompanyApp.Domain.Repositories.Addresses
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IDbConnection _db;

        public AddressRepository(IDbConnection db)
        {
            _db = db;
            InitializeDataBase();
        }

        private void InitializeDataBase()
        {
            _db.Execute($@"
                CREATE TABLE IF NOT EXISTS {Address.TABLE_NAME} (
                {nameof(Address.Id)} INTEGER PRIMARY KEY,
                {nameof(Address.StreetId)} INTEGER NOT NULL,
                {nameof(Address.BuildingNumber)} NVARCHAR(100) NOT NULL,
                {nameof(Address.AbonentId)} INTEGER NOT NULL,
                FOREIGN KEY ({nameof(Address.StreetId)}) REFERENCES {Street.TABLE_NAME} ({nameof(Street.Id)}),
                FOREIGN KEY ({nameof(Address.AbonentId)}) REFERENCES {Abonent.TABLE_NAME} ({nameof(Abonent.Id)}));");
        }

        public IEnumerable<Address> GetAll()
        {
            return _db.Query<Address>($"SELECT * FROM {Address.TABLE_NAME}");
        }
        void IAddressRepository.Add(Address address)
        {
            _db.Execute($@"
                INSERT INTO {Address.TABLE_NAME}
                ({nameof(address.StreetId)}, 
                {nameof(address.BuildingNumber)}, 
                {nameof(address.AbonentId)}) 
                VALUES (@StreetId, @BuildingNumber, @AbonentId)", address);
        }

        public Address Get(int abonentId)
        {
            return _db.QueryFirst<Address>(@$"
                SELECT {nameof(Address.BuildingNumber)}, s.{nameof(Street.Name)} AS {nameof(Address.StreetName)}
                FROM {Address.TABLE_NAME} AS a
                JOIN {Street.TABLE_NAME} AS s ON s.{nameof(Street.Id)} = a.{nameof(Address.StreetId)}
                WHERE {nameof(Address.AbonentId)} = @AbonentId", new { AbonentId = abonentId });
        }

        public int GetAbonentQuanityt(string streetName)
        {
            return _db.ExecuteScalar<int>(@$"
                SELECT COUNT (*) 
                FROM {Address.TABLE_NAME}
                JOIN {Street.TABLE_NAME} AS s ON {nameof(Address.StreetId)} = s.{nameof(Street.Id)}
                WHERE s.{nameof(Street.Name)} = @StreetName", new { StreetName = streetName });
        }
    }
}
