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
    [Route("api/tags")]
    [Produces("application/json")]
    public class TagsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public TagsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] TagsFilters filters)
        {
            return Ok(_dataManager.Tags.GetCountTags(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Tags.GetNamesTags(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Tag[]), 200)]
        public IActionResult Index([FromBody] TagsFilters filters)
        {
            return Ok(_dataManager.Tags.GetTags(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.Tags.ContainsTag(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Tag), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Tags.GetTag(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] Tag tag)
        {
            if (tag.Id == default)
            {
                if (_dataManager.Tags.SaveTag(tag))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = tag.Id,
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
        public IActionResult Update([FromBody] Tag tag)
        {
            if (tag.Id != default)
            {
                if (_dataManager.Tags.SaveTag(tag))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = tag.Id,
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
            _dataManager.Tags.DeleteTag(id);

            return Ok();
        }
    }
}
