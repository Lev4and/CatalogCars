using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Model.Database.Repositories.Default.Abstract;
using CatalogCars.Model.Database.Repositories.Default.EntityFramework.Sorters.Announcement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CatalogCars.Model.Database.Repositories.Default.EntityFramework
{
    public class EFAnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly CatalogCarsDbContext _context;
        private readonly IEnumerable<IAnnouncementsSorter> _sorters;

        public EFAnnouncementsRepository(CatalogCarsDbContext context, IEnumerable<IAnnouncementsSorter> sorters)
        {
            _context = context;
            _sorters = sorters;
        }

        public IQueryable<Announcement> GetAnnouncements(AnnouncementsFilters filters)
        {
            var sorter = _sorters.FirstOrDefault(sorter => sorter.SortingOption == filters.SortingOption);

            IQueryable<Announcement> announcements = _context.Announcements
                .Include(announcement => announcement.State)
                .Include(announcement => announcement.Price)
                .Include(announcement => announcement.Color)
                .Include(announcement => announcement.Status)
                .Include(announcement => announcement.Seller)
                    .ThenInclude(seller => seller.Location)
                        .ThenInclude(location => location.Region)
                .Include(announcement => announcement.Category)
                .Include(announcements => announcements.Section)
                .Include(announcements => announcements.Vehicle)
                    .ThenInclude(vehicle => vehicle.Vendor)
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.Generation)
                        .ThenInclude(generation => generation.Model)
                            .ThenInclude(model => model.Mark)
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.Configuration)
                        .ThenInclude(configuration => configuration.BodyType)
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.Configuration)
                        .ThenInclude(configuration => configuration.MainPhoto)
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(announcement => announcement.SteeringWheel)
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.TechnicalParameters)
                        .ThenInclude(technicalParameter => technicalParameter.GearType)
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.TechnicalParameters)
                        .ThenInclude(technicalParameter => technicalParameter.EngineType)
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.TechnicalParameters)
                        .ThenInclude(technicalParameter => technicalParameter.Transmission)
                .Include(announcement => announcement.Documents)
                    .ThenInclude(document => document.Pts)
                .Include(announcement => announcement.SellerType)
                .Include(announcement => announcement.Availability)
                .Include(announcement => announcement.AdditionalInformation);

            if (!string.IsNullOrEmpty(filters.SearchString))
            {
                announcements = announcements.Where(announcement =>
                    EF.Functions.Like(announcement.Vehicle.Generation.Model.Mark.Name + " " +
                        announcement.Vehicle.Generation.Model.Name + (announcement.Vehicle.Generation.Name != null ? " " +
                            announcement.Vehicle.Generation.Name : "") + (announcement.Vehicle.Generation.YearFrom != null ? " " +
                                announcement.Vehicle.Generation.YearFrom : ""), $"%{filters.SearchString}%"));
            }

            if (filters.Warranty != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Documents.Warranty == filters.Warranty);
            }

            if (filters.IsBeaten != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.State.IsBeaten == filters.IsBeaten);
            }

            if (filters.IsOriginal != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Documents.Pts.IsOriginal == filters.IsOriginal);
            }

            if (filters.StatusId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.StatusId == filters.StatusId);
            }

            if (filters.SectionId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.SectionId == filters.SectionId);
            }

            if (filters.CurrencyId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Price.CurrencyId == filters.CurrencyId);
            }

            if (filters.GearTypeId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Vehicle.TechnicalParameters.GearTypeId == filters.GearTypeId);
            }

            if (filters.EngineTypeId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Vehicle.TechnicalParameters.EngineTypeId == filters.EngineTypeId);
            }

            if (filters.SellerTypeId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.SellerTypeId == filters.SellerTypeId);
            }

            if (filters.TransmissionId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Vehicle.TechnicalParameters.TransmissionId == filters.TransmissionId);
            }

            if (filters.SteeringWheelId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Vehicle.SteeringWheelId == filters.SteeringWheelId);
            }

            if (filters.TagsIds.Count > 0)
            {
                announcements = announcements
                    .Include(announcement => announcement.Tags)
                    .Include(announcement => announcement.Vehicle)
                        .ThenInclude(vehicle => vehicle.Configuration)
                            .ThenInclude(vehicle => vehicle.Tags)
                    .Where(announcement => announcement.Vehicle.Configuration.Tags.Where(tag =>
                        filters.TagsIds.Contains(tag.TagId)).Count() == filters.TagsIds.Count ||
                            announcement.Tags.Where(tag => filters.TagsIds.Contains(tag.TagId)).Count() == filters.TagsIds.Count);
            }

            if (filters.MarksIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.MarksIds.Contains(announcement.Vehicle.Generation.Model.MarkId));
            }

            if (filters.ModelsIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.ModelsIds.Contains(announcement.Vehicle.Generation.ModelId));
            }

            if (filters.GenerationsIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.GenerationsIds.Contains(announcement.Vehicle.GenerationId));
            }

            if (filters.ColorsIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.ColorsIds.Contains(announcement.ColorId));
            }

            if (filters.VendorsIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.VendorsIds.Contains(announcement.Vehicle.VendorId));
            }

            if (filters.OptionsIds.Count > 0)
            {
                announcements = announcements
                    .Include(announcement => announcement.Vehicle)
                        .ThenInclude(vehicle => vehicle.Complectation)
                            .ThenInclude(complectation => complectation.Options)
                    .Where(announcement => announcement.Vehicle.Complectation.Options.Where(option =>
                        filters.OptionsIds.Contains(option.OptionId)).Count() == filters.OptionsIds.Count);
            }

            if (filters.BodyTypesIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.BodyTypesIds.Contains(announcement.Vehicle.Configuration.BodyTypeId));
            }

            if (filters.BodyTypeGroupsIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.BodyTypeGroupsIds.Contains(announcement.Vehicle.Configuration
                        .BodyType.BodyTypeGroupId));
            }

            if(filters.Region != null)
            {
                if (filters.SearchRadius != filters.MaxSearchRadius)
                {
                    announcements = announcements.Where(announcement => 2 * 6371 * Math.Asin(Math.Sqrt(
                        Math.Sin((announcement.Seller.Location.Region.Latitude * Math.PI / 180 - filters.Region.Latitude * Math.PI / 180) / 2) *
                            Math.Sin((announcement.Seller.Location.Region.Latitude * Math.PI / 180 - filters.Region.Latitude * Math.PI / 180) / 2) +
                                Math.Cos(filters.Region.Latitude * Math.PI / 180) *
                                    Math.Cos(announcement.Seller.Location.Region.Latitude * Math.PI / 180) *
                                        Math.Sin((announcement.Seller.Location.Region.Longitude * Math.PI / 180 - filters.Region.Longitude * Math.PI / 180) / 2) *
                                            Math.Sin((announcement.Seller.Location.Region.Longitude * Math.PI / 180 - filters.Region.Longitude * Math.PI / 180) / 2))) <= filters.SearchRadius);
                }
            }

            if (filters.RangeYear.CheckСhanges())
            {
                announcements = announcements.Where(announcement =>
                    announcement.Documents.Pts.Year >= filters.RangeYear.From &&
                        announcement.Documents.Pts.Year <= filters.RangeYear.To);
            }

            if (filters.RangePower.CheckСhanges())
            {
                announcements = announcements.Where(announcement =>
                    announcement.Vehicle.TechnicalParameters.Power >= filters.RangePower.From &&
                        announcement.Vehicle.TechnicalParameters.Power <= filters.RangePower.To);
            }

            if (filters.RangePrice.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Price.Value >=
                    filters.RangePrice.From && announcement.Price.Value <= filters.RangePrice.To);
            }

            if (filters.RangeMileage.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.State.Mileage >= 
                    filters.RangeMileage.From && announcement.State.Mileage <= filters.RangeMileage.To);
            }

            if (filters.RangePowerKvt.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.TechnicalParameters.PowerKvt >= 
                    filters.RangePowerKvt.From && announcement.Vehicle.TechnicalParameters.PowerKvt <= 
                        filters.RangePowerKvt.To);
            }

            if (filters.RangeFuelRate.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.TechnicalParameters.FuelRate >=
                    filters.RangeFuelRate.From && announcement.Vehicle.TechnicalParameters.FuelRate <=
                        filters.RangeFuelRate.To);
            }

            if (filters.RangeCreatedAt.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.AdditionalInformation.CreatedAt >= 
                    filters.RangeCreatedAt.From.Date && announcement.AdditionalInformation.CreatedAt <= 
                        filters.RangeCreatedAt.To.Date.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999));
            }

            if (filters.RangeDoorsCount.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.Configuration.DoorsCount >=
                    filters.RangeDoorsCount.From && announcement.Vehicle.Configuration.DoorsCount <=
                        filters.RangeDoorsCount.To);
            }

            if (filters.RangeOwnersNumber.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Documents.Pts.OwnersNumber >= 
                    filters.RangeOwnersNumber.From && announcement.Documents.Pts.OwnersNumber <= 
                        filters.RangeOwnersNumber.To);
            }

            if (filters.RangeAcceleration.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.TechnicalParameters.Acceleration >=
                    filters.RangeAcceleration.From && announcement.Vehicle.TechnicalParameters.Acceleration <=
                        filters.RangeAcceleration.To);
            }

            if (filters.RangeDisplacement.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.TechnicalParameters.Displacement >= 
                    filters.RangeDisplacement.From && announcement.Vehicle.TechnicalParameters.Displacement <= 
                        filters.RangeDisplacement.To);
            }

            if (filters.RangeClearanceMin.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.TechnicalParameters.ClearanceMin >= 
                    filters.RangeClearanceMin.From && announcement.Vehicle.TechnicalParameters.ClearanceMin <= 
                        filters.RangeClearanceMin.To);
            }

            if (filters.RangeTrunkVolumeMin.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.Configuration.TrunkVolumeMin >=
                    filters.RangeTrunkVolumeMin.From && announcement.Vehicle.Configuration.TrunkVolumeMin <=
                        filters.RangeTrunkVolumeMin.To);
            }

            if (filters.RangeTrunkVolumeMax.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.Configuration.TrunkVolumeMax >= 
                    filters.RangeTrunkVolumeMax.From && announcement.Vehicle.Configuration.TrunkVolumeMax <= 
                        filters.RangeTrunkVolumeMax.To);
            }

            if (sorter != null)
            {
                announcements = sorter.Sort(announcements);
            }

            return announcements
                .Skip((filters.NumberPage - 1) * filters.ItemsPerPage)
                .Take(filters.ItemsPerPage)
                .AsNoTracking();
        }

        public int GetCountAnnouncements(AnnouncementsFilters filters)
        {
            IQueryable<Announcement> announcements = _context.Announcements
                .Include(announcement => announcement.State)
                .Include(announcement => announcement.Price)
                .Include(announcement => announcement.Seller)
                    .ThenInclude(seller => seller.Location)
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.Generation)
                        .ThenInclude(generation => generation.Model)
                            .ThenInclude(model => model.Mark)
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.Configuration)
                        .ThenInclude(configuration => configuration.BodyType)
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.Complectation)
                        .ThenInclude(complectation => complectation.Options)
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.TechnicalParameters)
                .Include(announcement => announcement.Documents)
                    .ThenInclude(document => document.Pts)
                .Include(announcement => announcement.AdditionalInformation);

            if (!string.IsNullOrEmpty(filters.SearchString))
            {
                announcements = announcements.Where(announcement =>
                    EF.Functions.Like(announcement.Vehicle.Generation.Model.Mark.Name + " " +
                        announcement.Vehicle.Generation.Model.Name + (announcement.Vehicle.Generation.Name != null ? " " +
                            announcement.Vehicle.Generation.Name : "") + (announcement.Vehicle.Generation.YearFrom != null ? " " +
                                announcement.Vehicle.Generation.YearFrom : ""), $"%{filters.SearchString}%"));
            }

            if (filters.Warranty != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Documents.Warranty == filters.Warranty);
            }

            if (filters.IsBeaten != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.State.IsBeaten == filters.IsBeaten);
            }

            if (filters.IsOriginal != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Documents.Pts.IsOriginal == filters.IsOriginal);
            }

            if (filters.StatusId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.StatusId == filters.StatusId);
            }

            if (filters.SectionId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.SectionId == filters.SectionId);
            }

            if (filters.CurrencyId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Price.CurrencyId == filters.CurrencyId);
            }

            if (filters.GearTypeId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Vehicle.TechnicalParameters.GearTypeId == filters.GearTypeId);
            }

            if (filters.EngineTypeId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Vehicle.TechnicalParameters.EngineTypeId == filters.EngineTypeId);
            }

            if (filters.SellerTypeId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.SellerTypeId == filters.SellerTypeId);
            }

            if (filters.TransmissionId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Vehicle.TechnicalParameters.TransmissionId == filters.TransmissionId);
            }

            if (filters.SteeringWheelId != null)
            {
                announcements = announcements.Where(announcement =>
                    announcement.Vehicle.SteeringWheelId == filters.SteeringWheelId);
            }

            if (filters.TagsIds.Count > 0)
            {
                announcements = announcements
                    .Include(announcement => announcement.Tags)
                    .Include(announcement => announcement.Vehicle)
                        .ThenInclude(vehicle => vehicle.Configuration)
                            .ThenInclude(vehicle => vehicle.Tags)
                    .Where(announcement => announcement.Vehicle.Configuration.Tags.Where(tag =>
                        filters.TagsIds.Contains(tag.TagId)).Count() == filters.TagsIds.Count ||
                            announcement.Tags.Where(tag => filters.TagsIds.Contains(tag.TagId)).Count() == filters.TagsIds.Count);
            }

            if (filters.MarksIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.MarksIds.Contains(announcement.Vehicle.Generation.Model.MarkId));
            }

            if (filters.ModelsIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.ModelsIds.Contains(announcement.Vehicle.Generation.ModelId));
            }

            if (filters.GenerationsIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.GenerationsIds.Contains(announcement.Vehicle.GenerationId));
            }

            if (filters.ColorsIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.ColorsIds.Contains(announcement.ColorId));
            }

            if (filters.VendorsIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.VendorsIds.Contains(announcement.Vehicle.VendorId));
            }

            if (filters.OptionsIds.Count > 0)
            {
                announcements = announcements
                    .Include(announcement => announcement.Vehicle)
                        .ThenInclude(vehicle => vehicle.Complectation)
                            .ThenInclude(complectation => complectation.Options)
                    .Where(announcement => announcement.Vehicle.Complectation.Options.Where(option =>
                        filters.OptionsIds.Contains(option.OptionId)).Count() == filters.OptionsIds.Count);
            }

            if (filters.BodyTypesIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.BodyTypesIds.Contains(announcement.Vehicle.Configuration.BodyTypeId));
            }

            if (filters.BodyTypeGroupsIds.Count > 0)
            {
                announcements = announcements.Where(announcement =>
                    filters.BodyTypeGroupsIds.Contains(announcement.Vehicle.Configuration
                        .BodyType.BodyTypeGroupId));
            }

            if (filters.Region != null)
            {
                if(filters.SearchRadius != filters.MaxSearchRadius)
                {
                    announcements = announcements.Where(announcement => 2 * 6371 * Math.Asin(Math.Sqrt(
                        Math.Sin((announcement.Seller.Location.Region.Latitude * Math.PI / 180 - filters.Region.Latitude * Math.PI / 180) / 2) *
                            Math.Sin((announcement.Seller.Location.Region.Latitude * Math.PI / 180 - filters.Region.Latitude * Math.PI / 180) / 2) +
                                Math.Cos(filters.Region.Latitude * Math.PI / 180) *
                                    Math.Cos(announcement.Seller.Location.Region.Latitude * Math.PI / 180) *
                                        Math.Sin((announcement.Seller.Location.Region.Longitude * Math.PI / 180 - filters.Region.Longitude * Math.PI / 180) / 2) *
                                            Math.Sin((announcement.Seller.Location.Region.Longitude * Math.PI / 180 - filters.Region.Longitude * Math.PI / 180) / 2))) <= filters.SearchRadius);
                }
            }

            if (filters.RangeYear.CheckСhanges())
            {
                announcements = announcements.Where(announcement =>
                    announcement.Documents.Pts.Year >= filters.RangeYear.From &&
                        announcement.Documents.Pts.Year <= filters.RangeYear.To);
            }

            if (filters.RangePower.CheckСhanges())
            {
                announcements = announcements.Where(announcement =>
                    announcement.Vehicle.TechnicalParameters.Power >= filters.RangePower.From &&
                        announcement.Vehicle.TechnicalParameters.Power <= filters.RangePower.To);
            }

            if (filters.RangePrice.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Price.Value >=
                    filters.RangePrice.From && announcement.Price.Value <= filters.RangePrice.To);
            }

            if (filters.RangeMileage.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.State.Mileage >=
                    filters.RangeMileage.From && announcement.State.Mileage <= filters.RangeMileage.To);
            }

            if (filters.RangePowerKvt.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.TechnicalParameters.PowerKvt >=
                    filters.RangePowerKvt.From && announcement.Vehicle.TechnicalParameters.PowerKvt <=
                        filters.RangePowerKvt.To);
            }

            if (filters.RangeFuelRate.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.TechnicalParameters.FuelRate >=
                    filters.RangeFuelRate.From && announcement.Vehicle.TechnicalParameters.FuelRate <=
                        filters.RangeFuelRate.To);
            }

            if (filters.RangeCreatedAt.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.AdditionalInformation.CreatedAt >=
                    filters.RangeCreatedAt.From && announcement.AdditionalInformation.CreatedAt <=
                        filters.RangeCreatedAt.To);
            }

            if (filters.RangeDoorsCount.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.Configuration.DoorsCount >=
                    filters.RangeDoorsCount.From && announcement.Vehicle.Configuration.DoorsCount <=
                        filters.RangeDoorsCount.To);
            }

            if (filters.RangeOwnersNumber.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Documents.Pts.OwnersNumber >=
                    filters.RangeOwnersNumber.From && announcement.Documents.Pts.OwnersNumber <=
                        filters.RangeOwnersNumber.To);
            }

            if (filters.RangeAcceleration.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.TechnicalParameters.Acceleration >=
                    filters.RangeAcceleration.From && announcement.Vehicle.TechnicalParameters.Acceleration <=
                        filters.RangeAcceleration.To);
            }

            if (filters.RangeDisplacement.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.TechnicalParameters.Displacement >=
                    filters.RangeDisplacement.From && announcement.Vehicle.TechnicalParameters.Displacement <=
                        filters.RangeDisplacement.To);
            }

            if (filters.RangeClearanceMin.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.TechnicalParameters.ClearanceMin >=
                    filters.RangeClearanceMin.From && announcement.Vehicle.TechnicalParameters.ClearanceMin <=
                        filters.RangeClearanceMin.To);
            }

            if (filters.RangeTrunkVolumeMin.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.Configuration.TrunkVolumeMin >=
                    filters.RangeTrunkVolumeMin.From && announcement.Vehicle.Configuration.TrunkVolumeMin <=
                        filters.RangeTrunkVolumeMin.To);
            }

            if (filters.RangeTrunkVolumeMax.CheckСhanges())
            {
                announcements = announcements.Where(announcement => announcement.Vehicle.Configuration.TrunkVolumeMax >=
                    filters.RangeTrunkVolumeMax.From && announcement.Vehicle.Configuration.TrunkVolumeMax <=
                        filters.RangeTrunkVolumeMax.To);
            }

            return announcements.Count();
        }

        public IQueryable<string> GetNamesAnnouncements(string searchString)
        {
            return _context.Announcements
                .Include(announcement => announcement.Vehicle)
                    .ThenInclude(vehicle => vehicle.Generation)
                        .ThenInclude(generation => generation.Model)
                            .ThenInclude(model => model.Mark)
                .Where(announcement => EF.Functions.Like(announcement.Vehicle.Generation.Model.Mark.Name + " " + 
                    announcement.Vehicle.Generation.Model.Name + (announcement.Vehicle.Generation.Name != null ? " " + 
                        announcement.Vehicle.Generation.Name : "") + (announcement.Vehicle.Generation.YearFrom != null ? " " +
                            announcement.Vehicle.Generation.YearFrom : ""), $"%{searchString}%"))
                .OrderBy(announcement => announcement.Vehicle.Generation.Model.Mark.Name)
                    .ThenBy(announcement => announcement.Vehicle.Generation.Model.Name)
                        .ThenBy(announcement => announcement.Vehicle.Generation.Name)
                            .ThenBy(announcement => announcement.Vehicle.Generation.YearFrom)
                .Select(announcement => announcement.Vehicle.Generation.Model.Mark.Name + " " +
                    announcement.Vehicle.Generation.Model.Name + (announcement.Vehicle.Generation.Name != null ? " " +
                        announcement.Vehicle.Generation.Name : "") + (announcement.Vehicle.Generation.YearFrom != null ? " " +
                            announcement.Vehicle.Generation.YearFrom : ""))
                .Take(5)
                .AsNoTracking();
        }
    }
}
