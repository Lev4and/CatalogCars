using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/ptsTypes")]
    [Produces("application/json")]
    public class PtsTypesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public PtsTypesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] PtsTypesFilters filters)
        {
            return Ok(_dataManager.PtsTypes.GetCountPtsTypes(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.PtsTypes.GetNamesPtsTypes(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(PtsType[]), 200)]
        public IActionResult Index([FromBody] PtsTypesFilters filters)
        {
            return Ok(_dataManager.PtsTypes.GetPtsTypes(filters).ToArray());
        }
    }
}
