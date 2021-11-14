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
    [Route("api/photoClasses")]
    [Produces("application/json")]
    public class PhotoClassesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public PhotoClassesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] PhotoClassesFilters filters)
        {
            return Ok(_dataManager.PhotoClasses.GetCountPhotoClasses(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.PhotoClasses.GetNamesPhotoClasses(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(PhotoClass[]), 200)]
        public IActionResult Index([FromBody] PhotoClassesFilters filters)
        {
            return Ok(_dataManager.PhotoClasses.GetPhotoClasses(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.PhotoClasses.ContainsPhotoClass(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PhotoClass), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.PhotoClasses.GetPhotoClass(id));
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Add([FromBody] PhotoClass photoClass)
        {
            if (photoClass.Id == default)
            {
                if (_dataManager.PhotoClasses.SavePhotoClass(photoClass))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = photoClass.Id,
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
        public IActionResult Update([FromBody] PhotoClass photoClass)
        {
            if (photoClass.Id != default)
            {
                if (_dataManager.PhotoClasses.SavePhotoClass(photoClass))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = photoClass.Id,
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
            _dataManager.PhotoClasses.DeletePhotoClass(id);

            return Ok();
        }
    }
}
