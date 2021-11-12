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
    [Route("api/coordinates")]
    [Produces("application/json")]
    public class CoordinatesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public CoordinatesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] CoordinatesFilters filters)
        {
            return Ok(_dataManager.Coordinates.GetCountCoordinates(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Coordinates.GetNamesCoordinates(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Coordinate[]), 200)]
        public IActionResult Index([FromBody] CoordinatesFilters filters)
        {
            return Ok(_dataManager.Coordinates.GetCoordinates(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] Guid locationId, [FromQuery][Required] double latitude, [FromQuery][Required] double longitude)
        {
            return Ok(_dataManager.Coordinates.ContainsCoordinate(locationId, latitude, longitude));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Coordinate), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Coordinates.GetCoordinate(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] Coordinate coordinate)
        {
            if (coordinate.Id == default)
            {
                if (_dataManager.Coordinates.SaveCoordinate(coordinate))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = coordinate.Id,
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
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Update([FromBody] Coordinate coordinate)
        {
            if (coordinate.Id != default)
            {
                if (_dataManager.Coordinates.SaveCoordinate(coordinate))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = coordinate.Id,
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
            _dataManager.Coordinates.DeleteCoordinate(id);

            return Ok();
        }
    }
}
