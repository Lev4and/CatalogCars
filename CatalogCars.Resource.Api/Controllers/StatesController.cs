using CatalogCars.Model.Database;
using Microsoft.AspNetCore.Mvc;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/states")]
    [Produces("application/json")]
    public class StatesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public StatesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("minMileage")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MinMileage()
        {
            return Ok(_dataManager.States.GetMinMileage());
        }

        [HttpPost("maxMileage")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MaxMileage()
        {
            return Ok(_dataManager.States.GetMaxMileage());
        }
    }
}
