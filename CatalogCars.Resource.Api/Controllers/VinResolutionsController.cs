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
    [Route("api/vinResolutions")]
    [Produces("application/json")]
    public class VinResolutionsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public VinResolutionsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] VinResolutionsFilters filters)
        {
            return Ok(_dataManager.VinResolutions.GetCountVinResolutions(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.VinResolutions.GetNamesVinResolutions(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(VinResolution[]), 200)]
        public IActionResult Index([FromBody] VinResolutionsFilters filters)
        {
            return Ok(_dataManager.VinResolutions.GetVinResolutions(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.VinResolutions.ContainsVinResolution(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(VinResolution), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.VinResolutions.GetVinResolution(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] VinResolution vinResolution)
        {
            if (vinResolution.Id == default)
            {
                if (_dataManager.VinResolutions.SaveVinResolution(vinResolution))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = vinResolution.Id,
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
        public IActionResult Update([FromBody] VinResolution vinResolution)
        {
            if (vinResolution.Id != default)
            {
                if (_dataManager.VinResolutions.SaveVinResolution(vinResolution))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = vinResolution.Id,
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
            _dataManager.VinResolutions.DeleteVinResolution(id);

            return Ok();
        }
    }
}
