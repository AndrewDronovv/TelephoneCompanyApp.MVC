using TelephoneCompanyApp.Domain.Common;

namespace TelephoneCompanyApp.Domain.Entities
{
    public class Abonent : Entity
    {
        public const string TABLE_NAME = nameof(Abonent) + "s";
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string FullName => $"{Name} {LastName} {MiddleName}";
    }
}