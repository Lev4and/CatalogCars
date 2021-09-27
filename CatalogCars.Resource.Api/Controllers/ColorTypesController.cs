using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/colorTypes")]
    [Produces("application/json")]
    public class ColorTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public ColorTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] ColorTypesFilters filters)
        {
            return Ok(_dataManager.ColorTypes.GetCountColorTypes(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.ColorTypes.GetNamesColorTypes(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(ColorType[]), 200)]
        public IActionResult Index([FromBody] ColorTypesFilters filters)
        {
            return Ok(_dataManager.ColorTypes.GetColorTypes(filters).ToArray());
        }
    }
}
