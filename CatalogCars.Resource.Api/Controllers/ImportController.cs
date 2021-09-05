using CatalogCars.Model.Converters.AutoRu;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/import")]
    [Produces("application/json")]
    public class ImportController : Controller
    {
        public ImportController()
        {

        }

        [HttpPost("index")]
        public IActionResult Index(Announcement announcement)
        {
            return Ok();
        }
    }
}
