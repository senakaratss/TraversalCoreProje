using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Guide")]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }
        [Route("AddGuide")]
        [HttpPost]
        public IActionResult AddGuide(Guide p)
        {
            GuideValidator validationRules = new GuideValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                _guideService.TAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [Route("EditGuide/{id}")]
        [HttpGet]
        public IActionResult EditGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);
        }
        [Route("EditGuide/{id}")]
        [HttpPost]
        public IActionResult EditGuide(Guide p)
        {
            _guideService.TUpdate(p);
            return RedirectToAction("Index");
        }
        [Route("ChangeStatusToTrue/{id}")]
        public IActionResult ChangeStatusToTrue(int id)
        {
            _guideService.TChangeStatusToTrue(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }
        [Route("ChangeStatusToFalse/{id}")]
        public IActionResult ChangeStatusToFalse(int id)
        {
            _guideService.TChangeStatusToFalse(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" });
        }

    }
}
