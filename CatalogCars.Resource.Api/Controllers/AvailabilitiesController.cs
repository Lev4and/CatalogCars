using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/availabilities")]
    [Produces("application/json")]
    public class AvailabilitiesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public AvailabilitiesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] AvailabilitiesFilters filters)
        {
            return Ok(_dataManager.Availabilities.GetCountAvailabilities(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Availabilities.GetNamesAvailabilities(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(Availability[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.Availabilities.GetAvailabilities().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Availability[]), 200)]
        public IActionResult Index([FromBody] AvailabilitiesFilters filters)
        {
            return Ok(_dataManager.Availabilities.GetAvailabilities(filters).ToArray());
        }
    }
}
