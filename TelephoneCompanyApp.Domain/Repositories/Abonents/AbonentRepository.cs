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
            InitializeDataBase();
        }

        private void InitializeDataBase()
        {
            _db.Execute($@"
                CREATE TABLE IF NOT EXISTS {Abonent.TABLE_NAME} (
                {nameof(Abonent.Id)} INTEGER PRIMARY KEY, 
                {nameof(Abonent.Name)} NVARCHAR(100),
                {nameof(Abonent.LastName)} NVARCHAR(100),
                {nameof(Abonent.MiddleName)} NVARCHAR(100) NULL)");
        }

        public IEnumerable<Abonent> GetAll()
        {
            return _db.Query<Abonent>($"SELECT * FROM {Abonent.TABLE_NAME}");
        }

        public void Add(Abonent abonent)
        {
            _db.Execute($@"
                INSERT INTO {Abonent.TABLE_NAME} 
                ({nameof(abonent.Name)}, 
                {nameof(abonent.LastName)},
                {nameof(abonent.MiddleName)})
                VALUES (@Name, @LastName, @MiddleName)", abonent);
        }

        public int? GetIdOrDefault(string fio)
        {
            var fioData = fio.Split(' ');
            return _db.QueryFirstOrDefault<int?>(@$"
                SELECT {nameof(Abonent.Id)} 
                FROM {Abonent.TABLE_NAME} 
                WHERE {nameof(Abonent.Name)}='{fioData[1]}' 
                AND {nameof(Abonent.LastName)}='{fioData[0]}' 
                AND {nameof(Abonent.MiddleName)}='{fioData[2]}' LIMIT 1");
        }

        public Abonent GetById(int id)
        {
            return _db.QueryFirstOrDefault<Abonent>
            ($@"
                SELECT * FROM {Abonent.TABLE_NAME}  
                WHERE Id = @Id", new { Id = id });
        }

        public void Delete(int id)
        {
            _db.Execute($@"
                DELETE FROM {Abonent.TABLE_NAME} 
                WHERE Id = @Id", new { Id = id });
        }
    }
}
