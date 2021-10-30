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
    [Route("api/colorTypes")]
    [Produces("application/json")]
    public class ColorTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public ColorTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] ColorTypesFilters filters)
        {
            return Ok(_dataManager.ColorTypes.GetCountColorTypes(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.ColorTypes.GetNamesColorTypes(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ColorType[]), 200)]
        public IActionResult Index([FromBody] ColorTypesFilters filters)
        {
            return Ok(_dataManager.ColorTypes.GetColorTypes(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.ColorTypes.ContainsColorType(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ColorType), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.ColorTypes.GetColorType(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 404)]
        public IActionResult Add([FromBody] ColorType colorType)
        {
            if (colorType.Id == default)
            {
                return Ok(_dataManager.ColorTypes.SaveColorType(colorType));
            }

            return BadRequest(false);
        }

        [HttpPut("save")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 404)]
        public IActionResult Update([FromBody] ColorType colorType)
        {
            if (colorType.Id != default)
            {
                return Ok(_dataManager.ColorTypes.SaveColorType(colorType));
            }

            return BadRequest(false);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _dataManager.ColorTypes.DeleteColorType(id);

            return Ok();
        }
    }
}
