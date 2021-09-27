using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/colors")]
    [Produces("application/json")]
    public class ColorsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public ColorsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] ColorsFilters filters)
        {
            return Ok(_dataManager.Colors.GetCountColors(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Colors.GetNamesColors(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Color[]), 200)]
        public IActionResult Index([FromBody] ColorsFilters filters)
        {
            return Ok(_dataManager.Colors.GetColors(filters).ToArray());
        }
    }
}
