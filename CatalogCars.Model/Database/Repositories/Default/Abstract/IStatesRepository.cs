namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IStatesRepository
    {
        int GetMinMileage();

        int GetMaxMileage();
    }
}
