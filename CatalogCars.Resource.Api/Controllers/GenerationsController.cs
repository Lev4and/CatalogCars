using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/generations")]
    [Produces("application/json")]
    public class GenerationsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public GenerationsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] GenerationsFilters filters)
        {
            return Ok(_dataManager.Generations.GetCountGenerations(filters));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Generation[]), 200)]
        public IActionResult Index([FromBody] GenerationsFilters filters)
        {
            return Ok(_dataManager.Generations.GetGenerations(filters).ToArray());
        }

        [HttpPost("maxYearFromGeneration")]
        [ProducesResponseType(typeof(int?), 200)]
        public IActionResult MaxYearFromGeneration()
        {
            return Ok(_dataManager.Generations.GetMaxYearFromGeneration());
        }

        [HttpPost("minYearFromGeneration")]
        [ProducesResponseType(typeof(int?), 200)]
        public IActionResult MinYearFromGeneration()
        {
            return Ok(_dataManager.Generations.GetMinYearFromGeneration());
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Generations.GetNamesGenerations(searchString).ToArray());
        }
    }
}
