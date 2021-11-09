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
    [Route("api/sections")]
    [Produces("application/json")]
    public class SectionsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public SectionsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] SectionsFilters filters)
        {
            return Ok(_dataManager.Sections.GetCountSections(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Sections.GetNamesSections(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(Section[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.Sections.GetSections().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Section[]), 200)]
        public IActionResult Index([FromBody] SectionsFilters filters)
        {
            return Ok(_dataManager.Sections.GetSections(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.Sections.ContainsSection(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Section), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Sections.GetSection(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] Section section)
        {
            if (section.Id == default)
            {
                if (_dataManager.Sections.SaveSection(section))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = section.Id,
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
        public IActionResult Update([FromBody] Section section)
        {
            if (section.Id != default)
            {
                if (_dataManager.Sections.SaveSection(section))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = section.Id,
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
            _dataManager.Sections.DeleteSection(id);

            return Ok();
        }
    }
}
