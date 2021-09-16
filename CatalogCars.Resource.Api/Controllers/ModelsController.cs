using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Entities = CatalogCars.Model.Database.Entities;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/models")]
    [Produces("application/json")]
    public class ModelsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public ModelsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] ModelsFilters filters)
        {
            return Ok(_dataManager.Models.GetCountModels(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Models.GetNamesModels(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Entities.Model[]), 200)]
        public IActionResult Index([FromBody] ModelsFilters filters)
        {
            return Ok(_dataManager.Models.GetModels(filters).ToArray());
        }
    }
}
