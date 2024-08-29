using TelephoneCompanyApp.Domain.Common;
using TelephoneCompanyApp.Domain.Enums;

namespace TelephoneCompanyApp.Domain.Entities
{
    public class PhoneNumber : Entity
    {
        public const string TABLE_NAME = nameof(PhoneNumber) + "s";
        public string Phone { get; set; }
        public Telephone Telephone { get; set; }
        
        public int AbonentId { get; set; }
        public Abonent Abonent { get; set; }

        public PhoneNumber(string phone, Telephone telephone, int abonentId)
        {
            Phone = phone;
            Telephone = telephone;
            AbonentId = abonentId;
        }

        public PhoneNumber()
        {
            
        }
    }
}