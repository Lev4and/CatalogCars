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
    [Route("api/phones")]
    [Produces("application/json")]
    public class PhonesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public PhonesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] PhonesFilters filters)
        {
            return Ok(_dataManager.Phones.GetCountPhones(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Phones.GetNamesPhones(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Phone[]), 200)]
        public IActionResult Index([FromBody] PhonesFilters filters)
        {
            return Ok(_dataManager.Phones.GetPhones(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string value)
        {
            return Ok(_dataManager.Phones.ContainsPhone(value));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Phone), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Phones.GetPhone(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] Phone phone)
        {
            if (phone.Id == default)
            {
                if (_dataManager.Phones.SavePhone(phone))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = phone.Id,
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
        public IActionResult Update([FromBody] Phone option)
        {
            if (option.Id != default)
            {
                if (_dataManager.Phones.SavePhone(option))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = option.Id,
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
            _dataManager.Phones.DeletePhone(id);

            return Ok();
        }
    }
}
