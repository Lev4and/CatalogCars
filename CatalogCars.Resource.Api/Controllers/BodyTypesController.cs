using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/bodyTypes")]
    [Produces("application/json")]
    public class BodyTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public BodyTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] BodyTypesFilters filters)
        {
            return Ok(_dataManager.BodyTypes.GetCountBodyTypes(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.BodyTypes.GetNamesBodyTypes(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(BodyType[]), 200)]
        public IActionResult Index([FromBody] BodyTypesFilters filters)
        {
            return Ok(_dataManager.BodyTypes.GetBodyTypes(filters).ToArray());
        }
    }
}
