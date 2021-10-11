namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface IConfigurationsRepository
    {
        int GetMinDoorsCount();

        int GetMaxDoorsCount();

        double? GetMinTrunkVolumeMin();

        double? GetMaxTrunkVolumeMin();

        double? GetMinTrunkVolumeMax();

        double? GetMaxTrunkVolumeMax();
    }
}
