using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
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

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.Categories.ContainsCategory(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(BodyType), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Categories.GetCategory(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 404)]
        public IActionResult Add([FromBody] Category category)
        {
            if (category.Id == default)
            {
                return Ok(_dataManager.Categories.SaveCategory(category));
            }

            return BadRequest(false);
        }

        [HttpPut("save")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 404)]
        public IActionResult Update([FromBody] Category category)
        {
            if (category.Id != default)
            {
                return Ok(_dataManager.Categories.SaveCategory(category));
            }

            return BadRequest(false);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _dataManager.Categories.DeleteCategory(id);

            return Ok();
        }
    }
}
