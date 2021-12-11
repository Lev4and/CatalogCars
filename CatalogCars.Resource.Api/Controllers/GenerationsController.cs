using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/generations")]
    [Produces("application/json")]
    public class GenerationsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public GenerationsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] GenerationsFilters filters)
        {
            return Ok(_dataManager.Generations.GetCountGenerations(filters));
        }

        [HttpPost("byModelsIds/count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult CountGenerationsByModelsIds([FromBody] GenerationsFilters filters)
        {
            return Ok(_dataManager.Generations.GetCountGenerationsOfModels(filters));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Generation[]), 200)]
        public IActionResult Index([FromBody] GenerationsFilters filters)
        {
            return Ok(_dataManager.Generations.GetGenerations(filters).ToArray());
        }

        [HttpGet("byModelsIds")]
        [ProducesResponseType(typeof(Generation[]), 200)]
        public IActionResult GenerationsByModelsIds([FromQuery(Name = "modelId")] List<Guid> modelsIds)
        {
            return Ok(_dataManager.Generations.GetGenerationsOfModels(modelsIds).ToArray());
        }

        [HttpPost("byModelsIds")]
        [ProducesResponseType(typeof(Generation[]), 200)]
        public IActionResult GenerationsByModelsIds([FromBody] GenerationsFilters filters)
        {
            return Ok(_dataManager.Generations.GetGenerationsOfModels(filters).ToArray());
        }

        [HttpPost("maxYearFromGeneration")]
        [ProducesResponseType(typeof(int?), 200)]
        public IActionResult MaxYearFromGeneration()
        {
            return Ok(_dataManager.Generations.GetMaxYearFromGeneration());
        }

        [HttpPost("minYearFromGeneration")]
        [ProducesResponseType(typeof(int?), 200)]
        public IActionResult MinYearFromGeneration()
        {
            return Ok(_dataManager.Generations.GetMinYearFromGeneration());
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Generations.GetNamesGenerations(searchString).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] Guid modelId, [FromQuery] int? yearFrom, [FromQuery] string name)
        {
            return Ok(_dataManager.Generations.ContainsGeneration(modelId, yearFrom, name));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Generation), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Generations.GetGeneration(id));
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Add([FromBody] Generation generation)
        {
            if (generation.Id == default)
            {
                if (_dataManager.Generations.SaveGeneration(generation))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = generation.Id,
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
        public IActionResult Update([FromBody] Generation generation)
        {
            if (generation.Id != default)
            {
                if (_dataManager.Generations.SaveGeneration(generation))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = generation.Id,
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
            _dataManager.Generations.DeleteGeneration(id);

            return Ok();
        }
    }
}
