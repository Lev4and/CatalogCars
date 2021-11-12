﻿using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/sellerTypes")]
    [Produces("application/json")]
    public class SellerTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public SellerTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] SellerTypesFilters filters)
        {
            return Ok(_dataManager.SellerTypes.GetCountSellerTypes(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.SellerTypes.GetNamesSellerTypes(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(SellerType[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.SellerTypes.GetSellerTypes().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(SellerType[]), 200)]
        public IActionResult Index([FromBody] SellerTypesFilters filters)
        {
            return Ok(_dataManager.SellerTypes.GetSellerTypes(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.SellerTypes.ContainsSellerType(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(SellerType), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.SellerTypes.GetSellerType(id));
        }

        [HttpPost("save")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 404)]
        public IActionResult Add([FromBody] SellerType sellerType)
        {
            if (sellerType.Id == default)
            {
                if (_dataManager.SellerTypes.SaveSellerType(sellerType))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = sellerType.Id,
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
        public IActionResult Update([FromBody] SellerType sellerType)
        {
            if (sellerType.Id != default)
            {
                if (_dataManager.SellerTypes.SaveSellerType(sellerType))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = sellerType.Id,
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
            _dataManager.SellerTypes.DeleteSellerType(id);

            return Ok();
        }
    }
}
