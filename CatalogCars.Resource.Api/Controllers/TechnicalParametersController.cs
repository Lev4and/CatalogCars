using CatalogCars.Model.Database;
using Microsoft.AspNetCore.Mvc;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/technicalParameters")]
    [Produces("application/json")]
    public class TechnicalParametersController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public TechnicalParametersController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("minPower")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MinPower()
        {
            return Ok(_dataManager.TechnicalParameters.GetMinPower());
        }

        [HttpPost("maxPower")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MaxPower()
        {
            return Ok(_dataManager.TechnicalParameters.GetMaxPower());
        }

        [HttpPost("minPowerKvt")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MinPowerKvt()
        {
            return Ok(_dataManager.TechnicalParameters.GetMinPowerKvt());
        }

        [HttpPost("maxPowerKvt")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MaxPowerKvt()
        {
            return Ok(_dataManager.TechnicalParameters.GetMaxPowerKvt());
        }

        [HttpPost("minDisplacement")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MinDisplacement()
        {
            return Ok(_dataManager.TechnicalParameters.GetMinDisplacement());
        }

        [HttpPost("maxDisplacement")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MaxDisplacement()
        {
            return Ok(_dataManager.TechnicalParameters.GetMaxDisplacement());
        }

        [HttpPost("minClearanceMin")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MinClearanceMin()
        {
            return Ok(_dataManager.TechnicalParameters.GetMinClearanceMin());
        }

        [HttpPost("maxClearanceMin")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MaxClearanceMin()
        {
            return Ok(_dataManager.TechnicalParameters.GetMaxClearanceMin());
        }

        [HttpPost("minFuelRate")]
        [ProducesResponseType(typeof(double?), 200)]
        public IActionResult MinFuelRate()
        {
            return Ok(_dataManager.TechnicalParameters.GetMinFuelRate());
        }

        [HttpPost("maxFuelRate")]
        [ProducesResponseType(typeof(double?), 200)]
        public IActionResult MaxFuelRate()
        {
            return Ok(_dataManager.TechnicalParameters.GetMaxFuelRate());
        }

        [HttpPost("minAcceleration")]
        [ProducesResponseType(typeof(double), 200)]
        public IActionResult MinAcceleration()
        {
            return Ok(_dataManager.TechnicalParameters.GetMinAcceleration());
        }

        [HttpPost("maxAcceleration")]
        [ProducesResponseType(typeof(double), 200)]
        public IActionResult MaxAcceleration()
        {
            return Ok(_dataManager.TechnicalParameters.GetMaxAcceleration());
        }
    }
}
