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
    [Route("api/sellers")]
    [Produces("application/json")]
    public class SellersController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public SellersController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] SellersFilters filters)
        {
            return Ok(_dataManager.Sellers.GetCountSellers(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Sellers.GetNamesSellers(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Seller[]), 200)]
        public IActionResult Index([FromBody] SellersFilters filters)
        {
            return Ok(_dataManager.Sellers.GetSellers(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] Guid locationId)
        {
            return Ok(_dataManager.Sellers.ContainsSeller(locationId));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Seller), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Sellers.GetSeller(id));
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Add([FromBody] Seller seller)
        {
            if (seller.Id == default)
            {
                if (_dataManager.Sellers.SaveSeller(seller))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = seller.Id,
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
        public IActionResult Update([FromBody] Seller seller)
        {
            if (seller.Id != default)
            {
                if (_dataManager.Sellers.SaveSeller(seller))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = seller.Id,
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
            _dataManager.Sellers.DeleteSeller(id);

            return Ok();
        }
    }
}
