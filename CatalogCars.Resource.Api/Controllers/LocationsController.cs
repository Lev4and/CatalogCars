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
    [Route("api/locations")]
    [Produces("application/json")]
    public class LocationsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public LocationsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] LocationsFilters filters)
        {
            return Ok(_dataManager.Locations.GetCountLocations(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Locations.GetNamesLocations(searchString).ToArray());
        }

        [HttpPost()]
        [ProducesResponseType(typeof(Location[]), 200)]
        public IActionResult Index([FromBody] LocationsFilters filters)
        {
            return Ok(_dataManager.Locations.GetLocations(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] double latitude, [FromQuery][Required] double longitude)
        {
            return Ok(_dataManager.Locations.ContainsLocation(latitude, longitude));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Location), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Locations.GetLocation(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] Location location)
        {
            if (location.Id == default)
            {
                if (_dataManager.Locations.SaveLocation(location))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = location.Id,
                        Status = SaveResultStatus.Success,
                        Message = "Успешное добавление новой записи"
                    });
                }
                else
                {
                    return BadRequest(new SaveResult<object>()
                    {
                        Result = null,
                        Status = SaveResultStatus.Failure,
                        Message = "Запись с такими данными уже существует"
                    });
                }
            }

            return BadRequest(new SaveResult<object>()
            {
                Result = null,
                Status = SaveResultStatus.Failure,
                Message = "Идентификатор должен иметь значение по умолчанию"
            });
        }

        [HttpPut("save")]
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Update([FromBody] Location location)
        {
            if (location.Id != default)
            {
                if (_dataManager.Locations.SaveLocation(location))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = location.Id,
                        Status = SaveResultStatus.Success,
                        Message = "Успешное добавление новой записи"
                    });
                }
                else
                {
                    return BadRequest(new SaveResult<object>()
                    {
                        Result = null,
                        Status = SaveResultStatus.Failure,
                        Message = "Запись с такими данными уже существует"
                    });
                }
            }

            return BadRequest(new SaveResult<object>()
            {
                Result = null,
                Status = SaveResultStatus.Failure,
                Message = "Идентификатор не должен иметь значение по умолчанию"
            });
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            _dataManager.Locations.DeleteLocation(id);

            return Ok();
        }
    }
}
