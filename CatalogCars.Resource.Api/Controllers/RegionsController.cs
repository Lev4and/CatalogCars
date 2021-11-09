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
    [Route("api/regions")]
    [Produces("application/json")]
    public class RegionsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public RegionsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] RegionsFilters filters)
        {
            return Ok(_dataManager.Regions.GetCountRegions(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Regions.GetNamesRegions(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(RegionInformation[]), 200)]
        public IActionResult Index([FromBody] RegionsFilters filters)
        {
            return Ok(_dataManager.Regions.GetRegions(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string stringId)
        {
            return Ok(_dataManager.Regions.ContainsRegion(stringId));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(RegionInformation), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Regions.GetRegion(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] RegionInformation region)
        {
            if (region.Id == default)
            {
                if (_dataManager.Regions.SaveRegion(region))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = region.Id,
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
        public IActionResult Update([FromBody] RegionInformation region)
        {
            if (region.Id != default)
            {
                if (_dataManager.Regions.SaveRegion(region))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = region.Id,
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
            _dataManager.Regions.DeleteRegion(id);

            return Ok();
        }
    }
}
