using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AnonymousTypes;
using CatalogCars.Model.Database.AuxiliaryTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Entities = CatalogCars.Model.Database.Entities;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/models")]
    [Produces("application/json")]
    public class ModelsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public ModelsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] ModelsFilters filters)
        {
            return Ok(_dataManager.Models.GetCountModels(filters));
        }

        [HttpPost]
        [Route("byMarksIds/count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult CountModelsOfMarks([FromBody] ModelsFilters filters)
        {
            return Ok(_dataManager.Models.GetCountModelsOfMarks(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Models.GetNamesModels(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Entities.Model[]), 200)]
        public IActionResult Index([FromBody] ModelsFilters filters)
        {
            return Ok(_dataManager.Models.GetModels(filters).ToArray());
        }

        [HttpGet]
        [Route("byMarksIds")]
        [ProducesResponseType(typeof(Entities.Model[]), 200)]
        public IActionResult ModelsOfMarks([FromQuery] Guid[] marksIds)
        {
            return Ok(_dataManager.Models.GetModelsOfMarks(marksIds.ToList()).ToArray());
        }

        [HttpPost]
        [Route("byMarksIds")]
        [ProducesResponseType(typeof(Entities.Model[]), 200)]
        public IActionResult ModelsOfMarks([FromBody] ModelsFilters filters)
        {
            return Ok(_dataManager.Models.GetModelsOfMarks(filters).ToArray());
        }

        [HttpGet]
        [Route("byMark/popularityModels")]
        [ProducesResponseType(typeof(PopularityModels[]), 200)]
        public IActionResult PopularityModelsOfMark([FromQuery] Guid markId)
        {
            return Ok(_dataManager.Models.GetPopularityModelsOfMark(markId).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] Guid markId, [FromQuery][Required] string name)
        {
            return Ok(_dataManager.Models.ContainsModel(markId, name));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Entities.Model), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Models.GetModel(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] Entities.Model model)
        {
            if (model.Id == default)
            {
                if (_dataManager.Models.SaveModel(model))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = model.Id,
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
        public IActionResult Update([FromBody] Entities.Model model)
        {
            if (model.Id != default)
            {
                if (_dataManager.Models.SaveModel(model))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = model.Id,
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
            _dataManager.Models.DeleteModel(id);

            return Ok();
        }
    }
}
