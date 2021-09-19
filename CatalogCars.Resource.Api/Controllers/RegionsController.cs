using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/regions")]
    [Produces("application/json")]
    public class RegionsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public RegionsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] RegionsFilters filters)
        {
            return Ok(_dataManager.Regions.GetCountRegions(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Regions.GetNamesRegions(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(RegionInformation[]), 200)]
        public IActionResult Index([FromBody] RegionsFilters filters)
        {
            return Ok(_dataManager.Regions.GetRegions(filters).ToArray());
        }
    }
}
