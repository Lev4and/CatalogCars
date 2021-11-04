using CatalogCars.Model.Database;
using Microsoft.AspNetCore.Mvc;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/pts")]
    [Produces("application/json")]
    public class PtsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public PtsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("minYear")]
        [ProducesResponseType(typeof(int?), 200)]
        public IActionResult MinYear()
        {
            return Ok(_dataManager.Pts.GetMinYear());
        }

        [HttpPost("maxYear")]
        [ProducesResponseType(typeof(int?), 200)]
        public IActionResult MaxYear()
        {
            return Ok(_dataManager.Pts.GetMaxYear());
        }

        [HttpPost("minOwnersNumber")]
        [ProducesResponseType(typeof(int?), 200)]
        public IActionResult MinOwnersNumber()
        {
            return Ok(_dataManager.Pts.GetMinOwnersNumber());
        }

        [HttpPost("maxOwnersNumber")]
        [ProducesResponseType(typeof(int?), 200)]
        public IActionResult MaxOwnersNumber()
        {
            return Ok(_dataManager.Pts.GetMaxOwnersNumber());
        }
    }
}
