using CatalogCars.Resource.Requests.HttpRequesters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly RegionsRequester _regionsRequester;
        private readonly GenerationsRequester _generationsRequester;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            _regionsRequester = new RegionsRequester();
            _generationsRequester = new GenerationsRequester();
        }

        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("~/[action]")]
        public async Task<JsonResult> Generations([FromBody] string searchString)
        {
            return Json(await _generationsRequester.GetNamesGenerationsAsync(searchString));
        }

        [HttpPost]
        [Route("~/[action]")]
        public async Task<JsonResult> Regions([FromBody] string searchString)
        {
            return Json(await _regionsRequester.GetNamesRegionsAsync(searchString));
        }
    }
}
