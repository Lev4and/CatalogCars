using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/tags")]
    [Produces("application/json")]
    public class TagsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public TagsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] TagsFilters filters)
        {
            return Ok(_dataManager.Tags.GetCountTags(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Tags.GetNamesTags(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Tag[]), 200)]
        public IActionResult Index([FromBody] TagsFilters filters)
        {
            return Ok(_dataManager.Tags.GetTags(filters).ToArray());
        }
    }
}
