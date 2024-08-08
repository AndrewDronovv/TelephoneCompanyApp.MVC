using TelephoneCompanyApp.Domain.Common;
using TelephoneCompanyApp.Domain.Enums;

namespace TelephoneCompanyApp.Domain.Entities
{
    public class PhoneNumber : Entity
    {
        public string Phone { get; set; }
        public Telephone Telephone { get; set; }
        public int AbonentId { get; set; }
        public Abonent Abonent { get; set; }
    }
}