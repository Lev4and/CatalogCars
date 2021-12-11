using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests;
using CatalogCars.WebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogCars.WebApplication.Services
{
    public class CatalogViewModelGenerator
    {
        private readonly HttpClientContext _clientContext;

        public CatalogViewModelGenerator()
        {
            _clientContext = new HttpClientContext();
        }

        private async Task<CatalogViewModel> FillDataAsync(CatalogViewModel viewModel)
        {
            viewModel.Tags = (await _clientContext.Tags.GetTagsAsync()).ToList();
            viewModel.Marks = (await _clientContext.Marks.GetMarksAsync()).ToList();
            viewModel.Colors = (await _clientContext.Colors.GetColorsAsync()).ToList();
            viewModel.Vendors = (await _clientContext.Vendors.GetVendorsAsync()).ToList();
            viewModel.Options = (await _clientContext.Options.GetOptionsAsync()).ToList();
            viewModel.Statuses = (await _clientContext.Statuses.GetStatusesAsync()).ToList();
            viewModel.Sections = (await _clientContext.Sections.GetSectionsAsync()).ToList();
            viewModel.GearTypes = (await _clientContext.GearTypes.GetGearTypesAsync()).ToList();
            viewModel.EngineTypes = (await _clientContext.EngineTypes.GetEngineTypesAsync()).ToList();
            viewModel.SellerTypes = (await _clientContext.SellerTypes.GetSellerTypesAsync()).ToList();
            viewModel.Transmissions = (await _clientContext.Transmissions.GetTransmissionsAsync()).ToList();
            viewModel.Availabilities = (await _clientContext.Availabilities.GetAvailabilitiesAsync()).ToList();
            viewModel.SteeringWheels = (await _clientContext.SteeringWheels.GetSteeringWheelsAsync()).ToList();
            viewModel.BodyTypeGroups = (await _clientContext.BodyTypeGroups.GetBodyTypeGroupsAsync()).ToList();

            viewModel.Models = (await _clientContext.Models.GetModelsOfMarksAsync(viewModel.Filters.MarksIds.ToArray())).ToList();
            viewModel.BodyTypes = (await _clientContext.BodyTypes.GetBodyTypesOfBodyTypeGroupsAsync(viewModel.Filters.BodyTypeGroupsIds)).ToList();
            viewModel.Generations = (await _clientContext.Generations.GetGenerationsOfModelsAsync(viewModel.Filters.ModelsIds)).ToList();

            return viewModel;
        }

        private async Task<AnnouncementsFilters> GenerateFiltersAsync()
        {
            var filters = new AnnouncementsFilters();

            var minYear = await _clientContext.Pts.GetMinYearAsync();
            var maxYear = await _clientContext.Pts.GetMaxYearAsync();

            filters.RangeYear.SetRange(minYear, maxYear);

            var maxPower = await _clientContext.TechnicalParameters.GetMaxPowerAsync();
            var minPower = await _clientContext.TechnicalParameters.GetMinPowerAsync();

            filters.RangePower.SetRange(minPower, maxPower);

            filters.RangePrice.SetRange(0, 300000000);

            var minMileage = await _clientContext.States.GetMinMileageAsync();
            var maxMileage = await _clientContext.States.GetMaxMileageAsync();

            filters.RangeMileage.SetRange(minMileage, maxMileage);

            var minPowerKvt = await _clientContext.TechnicalParameters.GetMinPowerKvtAsync();
            var maxPowerKvt = await _clientContext.TechnicalParameters.GetMaxPowerKvtAsync();

            filters.RangePowerKvt.SetRange(minPowerKvt, maxPowerKvt);

            var minFuelRate = await _clientContext.TechnicalParameters.GetMinFuelRateAsync();
            var maxFuelRate = await _clientContext.TechnicalParameters.GetMaxFuelRateAsync();

            filters.RangeFuelRate.SetRange(minFuelRate, maxFuelRate);

            var minCreatedAt = await _clientContext.AnnouncementAdditionalInformation.GetMinCreatedAtAsync();
            var maxCreatedAt = await _clientContext.AnnouncementAdditionalInformation.GetMaxCreatedAtAsync();

            filters.RangeCreatedAt.SetRange(minCreatedAt, maxCreatedAt);

            var minDoorsCount = await _clientContext.Configurations.GetMinDoorsCountAsync();
            var maxDoorsCount = await _clientContext.Configurations.GetMaxDoorsCountAsync();

            filters.RangeDoorsCount.SetRange(minDoorsCount, maxDoorsCount);

            var minOwnersNumber = await _clientContext.Pts.GetMinOwnersNumberAsync();
            var maxOwnersNumber = await _clientContext.Pts.GetMaxOwnersNumberAsync();

            filters.RangeOwnersNumber.SetRange(minOwnersNumber, maxOwnersNumber);

            var minAcceleration = await _clientContext.TechnicalParameters.GetMinAccelerationAsync();
            var maxAcceleration = await _clientContext.TechnicalParameters.GetMaxAccelerationAsync();

            filters.RangeAcceleration.SetRange(minAcceleration, maxAcceleration);

            var minDisplacement = await _clientContext.TechnicalParameters.GetMinDisplacementAsync();
            var maxDisplacement = await _clientContext.TechnicalParameters.GetMaxDisplacementAsync();

            filters.RangeDisplacement.SetRange(minDisplacement, maxDisplacement);

            var minClearanceMin = await _clientContext.TechnicalParameters.GetMinClearanceMinAsync();
            var maxClearanceMin = await _clientContext.TechnicalParameters.GetMaxClearanceMinAsync();

            filters.RangeClearanceMin.SetRange(minClearanceMin, maxClearanceMin);

            var minTrunkVolumeMin = await _clientContext.Configurations.GetMinTrunkVolumeMinAsync();
            var maxTrunkVolumeMin = await _clientContext.Configurations.GetMaxTrunkVolumeMinAsync();

            filters.RangeTrunkVolumeMin.SetRange(minTrunkVolumeMin, maxTrunkVolumeMin);

            var minTrunkVolumeMax = await _clientContext.Configurations.GetMinTrunkVolumeMaxAsync();
            var maxTrunkVolumeMax = await _clientContext.Configurations.GetMaxTrunkVolumeMaxAsync();

            filters.RangeTrunkVolumeMax.SetRange(minTrunkVolumeMax, maxTrunkVolumeMax);

            return filters;
        }

        private async Task<Pagination> GeneratePaginationAsync(AnnouncementsFilters filters)
        {
            return new Pagination()
            {
                NumberPage = filters.NumberPage,
                ItemsPerPage = filters.ItemsPerPage,
                CountTotalItems = await _clientContext.Announcements.GetCountAnnouncementsAsync(filters)
            };
        }

        public async Task<CatalogViewModel> GenerateAsync()
        {
            var viewModel = new CatalogViewModel();

            viewModel.Filters = await GenerateFiltersAsync();
            viewModel.Pagination = await GeneratePaginationAsync(viewModel.Filters);
            viewModel.Announcements = (await _clientContext.Announcements.GetAnnouncementsAsync(viewModel.Filters)).ToList();
            
            return await FillDataAsync(viewModel);
        }

        public async Task<CatalogViewModel> GenerateAsync(AnnouncementsFilters filters)
        {
            var viewModel = new CatalogViewModel();

            viewModel.Filters = filters;
            viewModel.Filters.SearchString = "";
            viewModel.Pagination = await GeneratePaginationAsync(filters);
            viewModel.Announcements = (await _clientContext.Announcements.GetAnnouncementsAsync(filters)).ToList();

            return viewModel;
        }
    }
}
