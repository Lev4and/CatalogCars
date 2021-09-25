using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Produces("application/json")]
    public class CategoriesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public CategoriesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] CategoriesFilters filters)
        {
            return Ok(_dataManager.Categories.GetCountCategories(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Categories.GetNamesCategories(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Category[]), 200)]
        public IActionResult Index([FromBody] CategoriesFilters filters)
        {
            return Ok(_dataManager.Categories.GetCategories(filters).ToArray());
        }
    }
}
