using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/bodyTypeGroups")]
    [Produces("application/json")]
    public class BodyTypeGroupsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public BodyTypeGroupsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] BodyTypeGroupsFilters filters)
        {
            return Ok(_dataManager.BodyTypeGroups.GetCountBodyTypeGroups(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.BodyTypeGroups.GetNamesBodyTypeGroups(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(BodyTypeGroup[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.BodyTypeGroups.GetBodyTypeGroups().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(BodyTypeGroup[]), 200)]
        public IActionResult Index([FromBody] BodyTypeGroupsFilters filters)
        {
            return Ok(_dataManager.BodyTypeGroups.GetBodyTypeGroups(filters).ToArray());
        }
    }
}
