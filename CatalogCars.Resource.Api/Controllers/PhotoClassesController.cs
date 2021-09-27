using CatalogCars.Model.Database;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/photoClasses")]
    [Produces("application/json")]
    public class PhotoClassesController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public PhotoClassesController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("count")]
        [ProducesResponseType(typeof(int), 200)]
        public IActionResult Count([FromBody] PhotoClassesFilters filters)
        {
            return Ok(_dataManager.PhotoClasses.GetCountPhotoClasses(filters));
        }

        [HttpPost("names")]
        [ProducesResponseType(typeof(string[]), 200)]
        public IActionResult Names([FromBody] string searchString)
        {
            return Ok(_dataManager.PhotoClasses.GetNamesPhotoClasses(searchString).ToArray());
        }

        [HttpPost]
        [ProducesResponseType(typeof(PhotoClass[]), 200)]
        public IActionResult Index([FromBody] PhotoClassesFilters filters)
        {
            return Ok(_dataManager.PhotoClasses.GetPhotoClasses(filters).ToArray());
        }
    }
}
