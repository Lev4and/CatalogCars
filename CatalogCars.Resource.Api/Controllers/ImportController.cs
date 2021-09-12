using CatalogCars.Model.Converters.AutoRu;
using CatalogCars.Model.Importers.HighPerformance;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/import")]
    [Produces("application/json")]
    public class ImportController : Controller
    {
        private readonly AnnouncementImporter _importer;

        public ImportController(AnnouncementImporter importer)
        {
            _importer = importer;
        }

        [HttpPost("index")]
        [ProducesResponseType(typeof(Guid), 200)]
        public IActionResult Index(Announcement announcement)
        {
            return Ok(_importer.Import(announcement));
        }
    }
}
