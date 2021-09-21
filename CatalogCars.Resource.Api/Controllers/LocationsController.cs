using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/locations")]
    [Produces("application/json")]
    public class LocationsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public LocationsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] LocationsFilters filters)
        {
            return Ok(_dataManager.Locations.GetCountLocations(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Locations.GetNamesLocations(searchString).ToArray());
        }

        [HttpPost()]
        [ProducesResponseType(typeof(Location[]), 200)]
        public IActionResult Index([FromBody] LocationsFilters filters)
        {
            return Ok(_dataManager.Locations.GetLocations(filters).ToArray());
        }
    }
}
