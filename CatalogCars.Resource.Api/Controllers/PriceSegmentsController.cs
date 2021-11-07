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
    [Route("api/priceSegments")]
    [Produces("application/json")]
    public class PriceSegmentsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public PriceSegmentsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] PriceSegmentsFilters filters)
        {
            return Ok(_dataManager.PriceSegments.GetCountPriceSegments(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.PriceSegments.GetNamesPriceSegments(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(PriceSegment[]), 200)]
        public IActionResult Index([FromBody] PriceSegmentsFilters filters)
        {
            return Ok(_dataManager.PriceSegments.GetPriceSegments(filters).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(PriceSegment[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.PriceSegments.GetPriceSegments().ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.PriceSegments.ContainsPriceSegment(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(PriceSegment), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.PriceSegments.GetPriceSegment(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<Guid>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] PriceSegment priceSegment)
        {
            if (priceSegment.Id == default)
            {
                if (_dataManager.PriceSegments.SavePriceSegment(priceSegment))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = priceSegment.Id,
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
        public IActionResult Update([FromBody] PriceSegment priceSegment)
        {
            if (priceSegment.Id != default)
            {
                if (_dataManager.PriceSegments.SavePriceSegment(priceSegment))
                {
                    return Ok(new SaveResult<Guid>()
                    {
                        Result = priceSegment.Id,
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
            _dataManager.PriceSegments.DeletePriceSegment(id);

            return Ok();
        }
    }
}
