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
    [Route("api/vendors")]
    [Produces("application/json")]
    public class VendorsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public VendorsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] VendorsFilters filters)
        {
            return Ok(_dataManager.Vendors.GetCountVendors(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Vendors.GetNamesVendors(searchString).ToArray());
        }

        [HttpGet]
        [ProducesResponseType(typeof(Vendor[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.Vendors.GetVendors().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Vendor[]), 200)]
        public IActionResult Index([FromBody] VendorsFilters filters)
        {
            return Ok(_dataManager.Vendors.GetVendors(filters).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name, [FromQuery][Required] string ruName)
        {
            return Ok(_dataManager.Vendors.ContainsVendor(name, ruName));
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Vendor), 200)]
        public IActionResult Get([FromRoute] Guid id)
        {
            return Ok(_dataManager.Vendors.GetVendor(id));
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Add([FromBody] Vendor vendor)
        {
            if (vendor.Id == default)
            {
                if (_dataManager.Vendors.SaveVendor(vendor))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = vendor.Id,
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
        public IActionResult Update([FromBody] Vendor vendor)
        {
            if (vendor.Id != default)
            {
                if (_dataManager.Vendors.SaveVendor(vendor))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = vendor.Id,
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
            _dataManager.Vendors.DeleteVendor(id);

            return Ok();
        }
    }
}
