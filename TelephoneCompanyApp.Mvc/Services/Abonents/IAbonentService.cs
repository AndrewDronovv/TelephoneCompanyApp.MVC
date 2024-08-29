using TelephoneCompanyApp.Mvc.Services.Abonents.Dto;

namespace TelephoneCompanyApp.Mvc.Services.Abonents
{
    public interface IAbonentService
    {
        IEnumerable<AbonentDto> GetAll();
    }
}
