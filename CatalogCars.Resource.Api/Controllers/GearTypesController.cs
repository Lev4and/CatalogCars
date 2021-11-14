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
    [Route("api/gearTypes")]
    [Produces("application/json")]
    public class GearTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public GearTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] GearTypesFilters filters)
        {
            return Ok(_dataManager.GearTypes.GetCountGearTypes(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.GearTypes.GetNamesGearTypes(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(GearType[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.GearTypes.GetGearTypes().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(GearType[]), 200)]
        public IActionResult Index([FromBody] GearTypesFilters filters)
        {
            return Ok(_dataManager.GearTypes.GetGearTypes(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.GearTypes.ContainsGearType(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(GearType), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.GearTypes.GetGearType(id));
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Add([FromBody] GearType gearType)
        {
            if (gearType.Id == default)
            {
                if (_dataManager.GearTypes.SaveGearType(gearType))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = gearType.Id,
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

        [HttpPut("update")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Update([FromBody] GearType gearType)
        {
            if (gearType.Id != default)
            {
                if (_dataManager.GearTypes.SaveGearType(gearType))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = gearType.Id,
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

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery][Required] Guid id)
        {
            _dataManager.GearTypes.DeleteGearType(id);

            return Ok();
        }
    }
}
