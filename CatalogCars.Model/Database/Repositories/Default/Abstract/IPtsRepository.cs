namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IPtsRepository
    {
        int? GetMinOwnersNumber();

        int? GetMaxOwnersNumber();
    }
}
