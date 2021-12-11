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
    [Route("api/colors")]
    [Produces("application/json")]
    public class ColorsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public ColorsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] ColorsFilters filters)
        {
            return Ok(_dataManager.Colors.GetCountColors(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Colors.GetNamesColors(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(Color[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.Colors.GetColors().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Color[]), 200)]
        public IActionResult Index([FromBody] ColorsFilters filters)
        {
            return Ok(_dataManager.Colors.GetColors(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required][MaxLength(6)] string value)
        {
            return Ok(_dataManager.Colors.ContainsColor(value));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Color), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Colors.GetColor(id));
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Add([FromBody] Color color)
        {
            if (color.Id == default)
            {
                if (_dataManager.Colors.SaveColor(color))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = color.Id,
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
        public IActionResult Update([FromBody] Color color)
        {
            if (color.Id != default)
            {
                if (_dataManager.Colors.SaveColor(color))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = color.Id,
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
            _dataManager.Colors.DeleteColor(id);

            return Ok();
        }
    }
}
