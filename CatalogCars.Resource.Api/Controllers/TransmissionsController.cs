using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/transmissions")]
    [Produces("application/json")]
    public class TransmissionsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public TransmissionsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] TransmissionsFilters filters)
        {
            return Ok(_dataManager.Transmissions.GetCountTransmissions(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Transmissions.GetNamesTransmissions(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Transmission[]), 200)]
        public IActionResult Index([FromBody] TransmissionsFilters filters)
        {
            return Ok(_dataManager.Transmissions.GetTransmissions(filters).ToArray());
        }
    }
}
