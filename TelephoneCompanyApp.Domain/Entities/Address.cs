using TelephoneCompanyApp.Domain.Common;

namespace TelephoneCompanyApp.Domain.Entities
{
    public class Address : Entity
    {
        public int StreetId { get; set; }
        public Street Street { get; set; }
        public string BuildingNumber { get; set; }
        public int AbonentId { get; set; }
        public Abonent Abonent { get; set; }
    }
}