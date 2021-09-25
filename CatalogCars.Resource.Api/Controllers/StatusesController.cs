using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/statuses")]
    [Produces("application/json")]
    public class StatusesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public StatusesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] StatusesFilters filters)
        {
            return Ok(_dataManager.Statuses.GetCountStatuses(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Statuses.GetNamesStatuses(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Status[]), 200)]
        public IActionResult Index([FromBody] StatusesFilters filters)
        {
            return Ok(_dataManager.Statuses.GetStatuses(filters));
        }
    }
}
