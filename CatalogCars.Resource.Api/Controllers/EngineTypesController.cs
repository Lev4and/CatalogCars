using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/engineTypes")]
    [Produces("application/json")]
    public class EngineTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public EngineTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] EngineTypesFilters filters)
        {
            return Ok(_dataManager.EngineTypes.GetCountEngineTypes(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.EngineTypes.GetNamesEngineTypes(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(EngineType[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.EngineTypes.GetEngineTypes().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(EngineType[]), 200)]
        public IActionResult Index([FromBody] EngineTypesFilters filters)
        {
            return Ok(_dataManager.EngineTypes.GetEngineTypes(filters).ToArray());
        }
    }
}
