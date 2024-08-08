using TelephoneCompanyApp.Domain.Common;

namespace TelephoneCompanyApp.Domain.Entities
{
    public class Street : Entity
    {
        public const string TABLE_NAME = nameof(Street) + "s";
        public string Name { get; set; }

        public Street(string name)
        {
            Name = name;
        }
    }
}