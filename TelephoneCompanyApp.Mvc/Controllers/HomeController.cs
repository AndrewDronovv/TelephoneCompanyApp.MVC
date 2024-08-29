using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;
using TelephoneCompanyApp.Domain.Repositories.Abonents;
using TelephoneCompanyApp.Mvc.Services.Abonents;
using TelephoneCompanyApp.Mvc.Services.Abonents.Dto;
using TelephoneCompanyApp.Mvc.Services.Streets;
using TelephoneCompanyApp.Mvc.ViewModels.Home;

namespace TelephoneCompanyApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAbonentService _abonentService;
        private readonly IStreetService _streetService;
        private readonly IAbonentRepository _abonentRepository;

        public HomeController(IAbonentService abonenentService, IStreetService streetService, IAbonentRepository abonentRepository)
        {
            _abonentService = abonenentService;
            _streetService = streetService;
            _abonentRepository = abonentRepository;
        }

        public IActionResult Index()
        {
            var abonents = _abonentService.GetAll();
            var streets = _streetService.GetAll();
            var viewModel = new HomeViewModel
            {
                Abonents = abonents,
                Streets = streets,
            };

            return View(viewModel);
        }
        
        [HttpGet]
        public IActionResult Search(string phoneNumber)
        {
            var abonents = _abonentService.GetAll().Where(a => a.Phones.Any(p => p.Phone == phoneNumber));

            if (!abonents.Any())
            {
                return PartialView("_NoResultsMessage");
            }

            return PartialView("_AbonentsTable", abonents);
        }

        [HttpPost]
        public IActionResult LoadCsv()
        {
            var abonents = _abonentService
                .GetAll()
                .Select(a => new AbonentsCsvExportModel
                {
                    FullName = a.LastName + " " + a.Name + " " + a.MiddleName,
                    StreetName = a.Address.Name,
                    BuildingNumber = a.Address.BuildingNumber,
                    Phones = string.Join(", ", a.Phones.Select(p => p.Phone))
                })
                .ToList();
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream, new UTF8Encoding(true)))
            using (var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(abonents);

                streamWriter.Flush();
                var bytes = memoryStream.ToArray();

                return File(bytes, "text/csv", "abonents.csv");
            }
        }
        
        //[Route("[controller]/[action]/{id}")]
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var abonent = _abonentRepository.GetById(id);
        //    if (abonent == null)
        //    {
        //        return NotFound();
        //    }
        //    _abonentRepository.Delete(id);
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var abonent = _abonentRepository.GetById(id);
            if (abonent == null)
            {
                return NotFound();
            }
            _abonentRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Add(AbonentDto abonent)
        {
            return View(abonent);
        }
    }
}
