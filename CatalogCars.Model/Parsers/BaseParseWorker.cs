using AngleSharp.Html.Parser;

namespace CatalogCars.Model.Parsers
{
    public class BaseParseWorker
    {
        protected private readonly HtmlParser _htmlParser;

        public BaseParseWorker()
        {
            _htmlParser = new HtmlParser();
        }
    }
}
