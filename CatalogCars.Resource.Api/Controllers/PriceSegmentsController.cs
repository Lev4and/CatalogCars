using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
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
    }
}
