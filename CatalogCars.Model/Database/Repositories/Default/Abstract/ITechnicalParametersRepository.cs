namespace CatalogCars.Model.Database.Repositories.Default.Abstract
{
    public interface ITechnicalParametersRepository
    {
        int GetMinPower();

        int GetMaxPower();

        int GetMinPowerKvt();

        int GetMaxPowerKvt();

        int GetMinDisplacement();

        int GetMaxDisplacement();

        int GetMinClearanceMin();

        int GetMaxClearanceMin();

        double? GetMinFuelRate();

        double? GetMaxFuelRate();

        double GetMinAcceleration();

        double GetMaxAcceleration();
    }
}
