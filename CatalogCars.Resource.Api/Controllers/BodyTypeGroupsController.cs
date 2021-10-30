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

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string autoClass, [FromQuery] string ruName)
        {
            return Ok(_dataManager.BodyTypeGroups.ContainsBodyTypeGroup(autoClass, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(BodyTypeGroup), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.BodyTypeGroups.GetBodyTypeGroup(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 404)]
        public IActionResult Add([FromBody] BodyTypeGroup bodyTypeGroup)
        {
            if(bodyTypeGroup.Id == default)
            {
                return Ok(_dataManager.BodyTypeGroups.SaveBodyTypeGroup(bodyTypeGroup));
            }

            return BadRequest(false);
        }

        [HttpPut("save")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 404)]
        public IActionResult Update([FromBody] BodyTypeGroup bodyTypeGroup)
        {
            if (bodyTypeGroup.Id != default)
            {
                return Ok(_dataManager.BodyTypeGroups.SaveBodyTypeGroup(bodyTypeGroup));
            }

            return BadRequest(false);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _dataManager.BodyTypeGroups.DeleteBodyTypeGroup(id);

            return Ok();
        }
    }
}
