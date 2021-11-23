using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Controllers
{
    public class ErrorController : Controller
    {
        public ErrorController()
        {

        }
        
        [Route("~/[controller]/[action]")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}
