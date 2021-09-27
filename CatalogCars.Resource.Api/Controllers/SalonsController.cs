using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/salons")]
    [Produces("application/json")]
    public class SalonsController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public SalonsController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] SalonsFilters filters)
        {
            return Ok(_dataManager.Salons.GetCountSalons(filters));
        }

        [HttpPost("minRegistrationDate")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MinRegistrationDate()
        {
            return Ok(_dataManager.Salons.GetMinRegistrationDate());
        }

        [HttpPost("maxRegistrationDate")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult MaxRegistrationDate()
        {
            return Ok(_dataManager.Salons.GetMaxRegistrationDate());
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.Salons.GetNamesSalons(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(Salon[]), 200)]
        public IActionResult Index([FromBody] SalonsFilters filters)
        {
            return Ok(_dataManager.Salons.GetSalons(filters).ToArray());
        }
    }
}
