using TelephoneCompanyApp.Mvc.Services.Abonents.Dto;
using TelephoneCompanyApp.Mvc.Services.Streets.Dto;

namespace TelephoneCompanyApp.Mvc.ViewModels.Home
{
    public class HomeViewModel
    {
        public IEnumerable<AbonentDto> Abonents { get; set; }
        public IEnumerable<StreetDto> Streets { get; set; }
    }
}
