using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/sections")]
    [Produces("application/json")]
    public class SectionsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public SectionsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] SectionsFilters filters)
        {
            return Ok(_dataManager.Sections.GetCountSections(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Sections.GetNamesSections(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Section[]), 200)]
        public IActionResult Index([FromBody] SectionsFilters filters)
        {
            return Ok(_dataManager.Sections.GetSections(filters).ToArray());
        }
    }
}
