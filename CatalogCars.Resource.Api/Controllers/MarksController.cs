﻿using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AnonymousTypes;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/marks")]
    [Produces("application/json")]
    public class MarksController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public MarksController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] MarksFilters filters)
        {
            return Ok(_dataManager.Marks.GetCountMarks(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Marks.GetNamesMarks(searchString).ToArray());
        }

        [HttpGet]
        [Route("{markId}")]
        [ProducesResponseType(typeof(Mark), 200)]
        public IActionResult Index([FromRoute] Guid markId)
        {
            return Ok(_dataManager.Marks.GetMark(markId));
        }

        [HttpGet]
        [ProducesResponseType(typeof(Mark[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.Marks.GetMarks().ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Mark[]), 200)]
        public IActionResult Index([FromBody] MarksFilters filters)
        {
            return Ok(_dataManager.Marks.GetMarks(filters).ToArray());
        }

        [HttpGet("popularityMark")]
        [ProducesResponseType(typeof(PopularityMark[]), 200)]
        public IActionResult PopularityMark([FromQuery] Guid markId)
        {
            return Ok(_dataManager.Marks.GetPopularityMark(markId).ToArray());
        }

        [HttpGet("contains")]
        [ProducesResponseType(typeof(bool), 200)]
        public IActionResult Contains([FromQuery][Required] string name)
        {
            return Ok(_dataManager.Marks.ContainsMark(name));
        }

        [HttpPost("add")]
        [ProducesResponseType(typeof(SaveResult<object>), 200)]
        [ProducesResponseType(typeof(SaveResult<object>), 400)]
        public IActionResult Add([FromBody] Mark mark)
        {
            if (mark.Id == default)
            {
                if (_dataManager.Marks.SaveMark(mark))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = mark.Id,
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
        public IActionResult Update([FromBody] Mark mark)
        {
            if (mark.Id != default)
            {
                if (_dataManager.Marks.SaveMark(mark))
                {
                    return Ok(new SaveResult<object>()
                    {
                        Result = mark.Id,
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
            _dataManager.Marks.DeleteMark(id);

            return Ok();
        }

        [HttpGet("popularMarks")]
        [ProducesResponseType(typeof(PopularMark[]), 200)]
        public IActionResult PopularMarks()
        {
            return Ok(_dataManager.Marks.GetPopularMarks().ToArray());
        }
    }
}
