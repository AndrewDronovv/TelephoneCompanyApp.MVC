using Dapper;
using Microsoft.EntityFrameworkCore.Storage;
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
            using (var transaction = _db.BeginTransaction())
            {
                _db.Execute($@"
            Create Table if not exists {Street.TABLE_NAME} (
            {nameof(Street.Id)} integer primary key,
            {nameof(Street.Name)} text)");
                transaction.Commit();
            }
        }
        public IEnumerable<Street> GetAll()
        {
            return _db.Query<Street>($"select * from {Street.TABLE_NAME}");
        }

        public void Add(Street street)
        {
            //_db.Execute($@"Insert into {Street.TABLE_NAME} ({nameof(Street.Name)}) values ({street.Name})");
            _db.Execute($@"Insert into {Street.TABLE_NAME} ({nameof(Street.Name)}) values (@Name)", street);
        }
    }
}
