using AngleSharp.Html.Dom;
using CatalogCars.Model.Parsers.AutoRu.Types;
using System;
using System.Linq;

namespace CatalogCars.Model.Parsers.AutoRu
{
    public class PaginationParser : IParser<CarsPagination>
    {
        public CarsPagination Parse(IHtmlDocument document)
        {
            var carsPagination = document.QuerySelector("div.ListingCarsPagination");

            if (carsPagination != null)
            {
                return new CarsPagination()
                {
                    MaxNumberPage = Convert.ToInt32(document.QuerySelectorAll("a.ListingPagination-module__page").ToList()
                        .Last().QuerySelector("span.Button__text").TextContent)
                };
            }

            return new CarsPagination() { MaxNumberPage = 1 };
        }
    }
}
