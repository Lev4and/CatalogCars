using CatalogCars.Model.Database;
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

        [HttpPost]
        [ProducesResponseType(typeof(PriceSegment[]), 200)]
        public IActionResult Index()
        {
            return Ok(_dataManager.PriceSegments.GetPriceSegments().ToArray());
        }
    }
}
