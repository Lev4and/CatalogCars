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
    [Route("api/engineTypes")]
    [Produces("application/json")]
    public class EngineTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public EngineTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] EngineTypesFilters filters)
        {
            return Ok(_dataManager.EngineTypes.GetCountEngineTypes(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.EngineTypes.GetNamesEngineTypes(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(EngineType[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.EngineTypes.GetEngineTypes().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(EngineType[]), 200)]
        public IActionResult Index([FromBody] EngineTypesFilters filters)
        {
            return Ok(_dataManager.EngineTypes.GetEngineTypes(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.EngineTypes.ContainsEngineType(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(EngineType), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.EngineTypes.GetEngineType(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 404)]
        public IActionResult Add([FromBody] EngineType engineType)
        {
            if (engineType.Id == default)
            {
                return Ok(_dataManager.EngineTypes.SaveEngineType(engineType));
            }

            return BadRequest(false);
        }

        [HttpPut("save")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(typeof(bool), 404)]
        public IActionResult Update([FromBody] EngineType engineType)
        {
            if (engineType.Id != default)
            {
                return Ok(_dataManager.EngineTypes.SaveEngineType(engineType));
            }

            return BadRequest(false);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _dataManager.EngineTypes.DeleteEngineType(id);

            return Ok();
        }
    }
}
