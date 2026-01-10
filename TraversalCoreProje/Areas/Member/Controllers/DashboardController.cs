using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userMannager;

        public DashboardController(UserManager<AppUser> userMannager)
        {
            _userMannager = userMannager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userMannager.FindByNameAsync(User.Identity.Name);
            ViewBag.username = values.Name + " " + values.Surname;
            ViewBag.userImage = values.ImageUrl;
            return View();
        }
        public async Task<IActionResult> MemberDashboard()
        {
            return View();
        }
    }
}
