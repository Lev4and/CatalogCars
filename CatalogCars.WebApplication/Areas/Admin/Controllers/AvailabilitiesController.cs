using Microsoft.AspNetCore.Mvc;

namespace CatalogCars.WebApplication.Areas.Admin.Controllers
{
    public class AvailabilitiesController : Controller
    {
        public AvailabilitiesController()
        {

        }

        [Route("~/Admin/Availabilities")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
