using CatalogCars.Model.Database;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CatalogCars.Resource.Api.Controllers
{
    [ApiController]
    [Route("api/announcementAdditionalInformation")]
    [Produces("application/json")]
    public class AnnouncementAdditionalInformationController : Controller
    {
        private readonly DefaultDataManager _dataManager;

        public AnnouncementAdditionalInformationController(DefaultDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        [HttpPost("minCreatedAt")]
        [ProducesResponseType(typeof(DateTime), 200)]
        public IActionResult MinCreatedAt()
        {
            return Ok(_dataManager.AnnouncementAdditionalInformation.GetMinCreatedAt());
        }

        [HttpPost("maxCreatedAt")]
        [ProducesResponseType(typeof(DateTime), 200)]
        public IActionResult MaxCreatedAt()
        {
            return Ok(_dataManager.AnnouncementAdditionalInformation.GetMaxCreatedAt());
        }
    }
}
