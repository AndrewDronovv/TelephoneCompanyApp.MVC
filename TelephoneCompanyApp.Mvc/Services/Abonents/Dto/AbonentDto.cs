using TelephoneCompanyApp.Mvc.Dto;
using TelephoneCompanyApp.Mvc.Dto.Addresses;
using TelephoneCompanyApp.Mvc.Dto.Phones;

namespace TelephoneCompanyApp.Mvc.Services.Abonents.Dto
{
    public class AbonentDto : EntityDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string FullName => $"{LastName} {Name} {MiddleName}";
        public AddressDto Address { get; set; }
        public IEnumerable<PhoneDto> Phones { get; set; }
    }
}
