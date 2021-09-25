using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/steeringWheels")]
    [Produces("application/json")]
    public class SteeringWheelsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public SteeringWheelsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] SteeringWheelsFilters filters)
        {
            return Ok(_dataManager.SteeringWheels.GetCountSteeringWheels(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.SteeringWheels.GetNamesSteeringWheels(searchString).ToArray());
        }

        [HttpPost()]
        [ProducesResponseType(typeof(SteeringWheel[]), 200)]
        public IActionResult Index([FromBody] SteeringWheelsFilters filters)
        {
            return Ok(_dataManager.SteeringWheels.GetSteeringWheels(filters).ToArray());
        }
    }
}
