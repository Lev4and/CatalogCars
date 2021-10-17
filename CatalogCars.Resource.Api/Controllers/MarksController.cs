using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AnonymousTypes;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
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
        [ProducesResponseType(typeof(Mark), 200)]
        public IActionResult Index([FromQuery] Guid markId)
        {
            return Ok(_dataManager.Marks.GetMark(markId));
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
    }
}
