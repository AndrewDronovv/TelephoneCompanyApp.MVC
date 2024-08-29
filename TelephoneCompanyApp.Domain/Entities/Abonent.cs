using TelephoneCompanyApp.Domain.Common;

namespace TelephoneCompanyApp.Domain.Entities
{
    public class Abonent : Entity
    {
        public const string TABLE_NAME = nameof(Abonent) + "s";
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public string FullName => $"{LastName} {Name} {MiddleName}";

        public Abonent(string name, string lastName, string? middleName)
        {
            LastName = lastName;
            Name = name;
            MiddleName = middleName;
        }
        public Abonent()
        {

        }
    }
}