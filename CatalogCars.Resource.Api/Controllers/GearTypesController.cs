using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/gearTypes")]
    [Produces("application/json")]
    public class GearTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public GearTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] GearTypesFilters filters)
        {
            return Ok(_dataManager.GearTypes.GetCountGearTypes(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.GearTypes.GetNamesGearTypes(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(GearType[]), 200)]
        public IActionResult Index([FromBody] GearTypesFilters filters)
        {
            return Ok(_dataManager.GearTypes.GetGearTypes(filters).ToArray());
        }
    }
}
