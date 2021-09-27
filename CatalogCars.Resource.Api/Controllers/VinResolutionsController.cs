using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/vinResolutions")]
    [Produces("application/json")]
    public class VinResolutionsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public VinResolutionsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] VinResolutionsFilters filters)
        {
            return Ok(_dataManager.VinResolutions.GetCountVinResolutions(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.VinResolutions.GetNamesVinResolutions(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(VinResolution[]), 200)]
        public IActionResult Index([FromBody] VinResolutionsFilters filters)
        {
            return Ok(_dataManager.VinResolutions.GetVinResolutions(filters).ToArray());
        }
    }
}
