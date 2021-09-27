using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/coordinates")]
    [Produces("application/json")]
    public class CoordinatesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public CoordinatesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] CoordinatesFilters filters)
        {
            return Ok(_dataManager.Coordinates.GetCountCoordinates(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Coordinates.GetNamesCoordinates(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coordinate[]), 200)]
        public IActionResult Index([FromBody] CoordinatesFilters filters)
        {
            return Ok(_dataManager.Coordinates.GetCoordinates(filters).ToArray());
        }
    }
}
