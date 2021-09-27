using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/phones")]
    [Produces("application/json")]
    public class PhonesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public PhonesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] PhonesFilters filters)
        {
            return Ok(_dataManager.Phones.GetCountPhones(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Phones.GetNamesPhones(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Phone[]), 200)]
        public IActionResult Index([FromBody] PhonesFilters filters)
        {
            return Ok(_dataManager.Phones.GetPhones(filters).ToArray());
        }
    }
}
