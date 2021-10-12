using Microsoft.AspNetCore.Mvc;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        [Route("~/Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
