using CatalogCars.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogCars.WebApplication.Components
{
    public class SearchForm : ViewComponent
    {
        public SearchForm()
        {

        }

        public IViewComponentResult Invoke()
        {
            return View("Default", new SearchFormViewModel() { Regions = "", Generations = "" } );
        }
    }
}
