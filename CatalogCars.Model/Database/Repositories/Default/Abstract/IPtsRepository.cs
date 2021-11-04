namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPtsRepository
    {
        int? GetMinYear();

        int? GetMaxYear();

        int? GetMinOwnersNumber();

        int? GetMaxOwnersNumber();
    }
}
