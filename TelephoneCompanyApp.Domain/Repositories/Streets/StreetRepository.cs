using Dapper;
using System.Data;
using TelephoneCompanyApp.Domain.Entities;

namespace TelephoneCompanyApp.Domain.Repositories.Streets
{
    public class StreetRepository : IStreetRepository
    {
        private readonly IDbConnection _db;
        public StreetRepository(IDbConnection db)
        {
            _db = db;
            InitializeDataBase();
        }

        private void InitializeDataBase()
        {
            _db.Execute($@"
                CREATE TABLE IF NOT EXISTS {Street.TABLE_NAME} (
                {nameof(Street.Id)} INTEGER PRIMARY KEY,
                {nameof(Street.Name)} NVARCHAR(100))");
        }

        public IEnumerable<Street> GetAll()
        {
            return _db.Query<Street>($"SELECT * FROM {Street.TABLE_NAME}");
        }

        public void Add(Street street)
        {
            //_db.Execute($@"Insert into {Street.TABLE_NAME} ({nameof(Street.Name)}) values ({street.Name})");
            _db.Execute($@"INSERT INTO {Street.TABLE_NAME} ({nameof(Street.Name)}) VALUES (@Name)", street);
        }

        public int? GetStreetIdOrDefault(string name)
        {
            return _db.QueryFirstOrDefault<int?>(@$"
                SELECT {nameof(Street.Id)} 
                FROM {Street.TABLE_NAME} 
                WHERE {nameof(Street.Name)}='{name}' LIMIT 1");
        }
    }
}
