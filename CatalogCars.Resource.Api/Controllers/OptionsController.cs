using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/options")]
    [Produces("application/json")]
    public class OptionsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public OptionsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] OptionsFilters filters)
        {
            return Ok(_dataManager.Options.GetCountOptions(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Options.GetNamesOptions(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Option[]), 200)]
        public IActionResult Index([FromBody] OptionsFilters filters)
        {
            return Ok(_dataManager.Options.GetOptions(filters).ToArray());
        }
    }
}
