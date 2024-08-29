using TelephoneCompanyApp.Domain.Common;

namespace TelephoneCompanyApp.Domain.Entities
{
    public class Address : Entity
    {
        public const string TABLE_NAME = nameof(Address) + "es";

        public int StreetId { get; set; }
        public Street Street { get; set; }

        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }

        public int AbonentId { get; set; }
        public Abonent Abonent { get; set; }

        public Address(int streetId, string buildingNumber, int abonentId)
        {
            StreetId = streetId;
            BuildingNumber = buildingNumber;
            AbonentId = abonentId;
        }
        public Address()
        {
            
        }
    }
}