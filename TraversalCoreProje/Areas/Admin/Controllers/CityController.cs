using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;
        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }
        [HttpPost]
        public IActionResult AddCityDestination(Destination p)
        {
            p.Status = true;
            _destinationService.TAdd(p);
            var values = JsonConvert.SerializeObject(p);
            return Json(values);
        }
        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }
        public IActionResult UpdateCity(Destination p)
        {
            var values = _destinationService.TGetByID(p.DestinationID);
            p.Status = values.Status;
            p.Price = values.Price;
            p.Image = values.Image;
            p.Description = values.Description;
            p.Capacity = values.Capacity;
            p.CoverImage = values.CoverImage;
            p.Details1 = values.Details1;
            p.Details2 = values.Details2;
            p.Image2 = values.Image2;
            _destinationService.TUpdate(p);
            var jsonValues = JsonConvert.SerializeObject(p);
            return Json(jsonValues);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityID=1,
        //        CityName="Amsterdam",
        //        CityCountry="Hollanda"
        //    },
        //    new CityClass
        //    {
        //        CityID=2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    },

        //    new CityClass
        //    {
        //        CityID=3,
        //        CityName="Paris",
        //        CityCountry="Fransa"
        //    },
        //};


    }
}
