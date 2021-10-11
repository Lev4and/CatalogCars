using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/announcements")]
    [Produces("application/json")]
    public class AnnouncementsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public AnnouncementsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] AnnouncementsFilters filters)
        {
            return Ok(_dataManager.Announcements.GetCountAnnouncements(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Announcements.GetNamesAnnouncements(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Announcement[]), 200)]
        public IActionResult Index([FromBody] AnnouncementsFilters filters)
        {
            return Ok(_dataManager.Announcements.GetAnnouncements(filters).ToArray());
        }
    }
}
