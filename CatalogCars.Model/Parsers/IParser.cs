using AngleSharp.Html.Dom;

namespace CatalogCars.Model.Parsers
{
    public interface IParser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
