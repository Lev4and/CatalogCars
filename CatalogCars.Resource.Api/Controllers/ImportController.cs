using CatalogCars.Model.Converters.AutoRu;
using CatalogCars.Model.Importers.HighPerformance;
using CatalogCars.Resource.Api.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/import")]
    [Produces("application/json")]
    public class ImportController : Controller
    {
        private readonly IHubContext<AnnouncementsHub> _announcementshubContext;
        private readonly AnnouncementImporter _importer;

        public ImportController(IHubContext<AnnouncementsHub> announcementshubContext, AnnouncementImporter importer)
        {
            _announcementshubContext = announcementshubContext;
            _importer = importer;
        }

        [HttpPost("index")]
        [ProducesResponseType(typeof(Guid), 200)]
        public async Task<IActionResult> Index(Announcement announcement)
        {
            await _announcementshubContext.Clients.All.SendAsync("Receive", new Announcement[1] { announcement });

            return Ok(_importer.Import(announcement));
        }
    }
}
