using CatalogCars.Model.Database;
using Microsoft.AspNetCore.Mvc;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/configurations")]
    [Produces("application/json")]
    public class ConfigurationsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public ConfigurationsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("maxDoorsCount")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MaxDoorsCount()
        {
            return Ok(_dataManager.Configurations.GetMaxDoorsCount());
        }

        [HttpPost("maxTrunkVolumeMax")]
        [ProducesResponseType(typeof(double?), 200)]
        public IActionResult MaxTrunkVolumeMax()
        {
            return Ok(_dataManager.Configurations.GetMaxTrunkVolumeMax());
        }

        [HttpPost("maxTrunkVolumeMin")]
        [ProducesResponseType(typeof(double?), 200)]
        public IActionResult MaxTrunkVolumeMin()
        {
            return Ok(_dataManager.Configurations.GetMaxTrunkVolumeMin());
        }

        [HttpPost("minDoorsCount")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MinDoorsCount()
        {
            return Ok(_dataManager.Configurations.GetMinDoorsCount());
        }

        [HttpPost("minTrunkVolumeMax")]
        [ProducesResponseType(typeof(double?), 200)]
        public IActionResult MinTrunkVolumeMax()
        {
            return Ok(_dataManager.Configurations.GetMinTrunkVolumeMax());
        }

        [HttpPost("minTrunkVolumeMin")]
        [ProducesResponseType(typeof(double?), 200)]
        public IActionResult MinTrunkVolumeMin()
        {
            return Ok(_dataManager.Configurations.GetMinTrunkVolumeMin());
        }
    }
}
