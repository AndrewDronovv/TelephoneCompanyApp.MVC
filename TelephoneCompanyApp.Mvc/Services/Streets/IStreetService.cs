using TelephoneCompanyApp.Mvc.Services.Streets.Dto;

namespace TelephoneCompanyApp.Mvc.Services.Streets
{
    public interface IStreetService
    {
        IEnumerable<StreetDto> GetAll();
    }
}
