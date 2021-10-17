using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class AnnouncementsFilters : IFilters
    {
        public bool? Warranty { get; set; }

        public bool? IsBeaten { get; set; }

        public bool? IsOriginal { get; set; }

        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public string SearchString { get; set; }

        public SortingOption SortingOption { get; set; }

        public Guid? StatusId { get; set; }

        public Guid? SectionId { get; set; }

        public Guid? CurrencyId { get; set; }

        public Guid? GearTypeId { get; set; }

        public Guid? EngineTypeId { get; set; }

        public Guid? SellerTypeId { get; set; }

        public Guid? TransmissionId { get; set; }

        public Guid? AvailabilityId { get; set; }

        public Guid? SteeringWheelId { get; set; }

        public RangePower RangePower { get; set; }

        public RangePrice RangePrice { get; set; }

        public RangeMileage RangeMileage { get; set; }

        public RangePowerKvt RangePowerKvt { get; set; }

        public RangeFuelRate RangeFuelRate { get; set; }

        public RangeCreatedAt RangeCreatedAt { get; set; }

        public RangeDoorsCount RangeDoorsCount { get; set; }

        public RangeOwnersNumber RangeOwnersNumber { get; set; }

        public RangeAcceleration RangeAcceleration { get; set; }

        public RangeDisplacement RangeDisplacement { get; set; }

        public RangeClearanceMin RangeClearanceMin { get; set; }

        public RangeTrunkVolume RangeTrunkVolumeMin { get; set; }

        public RangeTrunkVolume RangeTrunkVolumeMax { get; set; }

        public List<int> Limits { get; set; }

        public List<Guid> TagsIds { get; set; }

        public List<Guid> MarksIds { get; set; }

        public List<Guid> ModelsIds { get; set; }

        public List<Guid> ColorsIds { get; set; }

        public List<Guid> VendorsIds { get; set; }

        public List<Guid> RegionsIds { get; set; }

        public List<Guid> OptionsIds { get; set; }

        public List<Guid> BodyTypesIds { get; set; }

        public List<Guid> GenerationsIds { get; set; }

        public List<Guid> BodyTypeGroupsIds { get; set; }

        public Dictionary<bool?, string> WarrantyValues { get; set; }

        public Dictionary<bool?, string> IsBeatenValues { get; set; }

        public Dictionary<bool?, string> IsOriginalValues { get; set; }

        public Dictionary<SortingOption, string> SortingOptions { get; set; } 

        public AnnouncementsFilters()
        {
            Reset();
        }

        public void Reset()
        {
            Warranty = null;
            IsBeaten = null;
            IsOriginal = null;
            NumberPage = 1;
            ItemsPerPage = 25;
            SearchString = "";
            SortingOption = SortingOption.Default;
            StatusId = null;
            SectionId = null;
            CurrencyId = null;
            GearTypeId = null;
            EngineTypeId = null;
            SellerTypeId = null;
            TransmissionId = null;
            AvailabilityId = null;
            SteeringWheelId = null;
            TagsIds = new List<Guid>();
            MarksIds = new List<Guid>();
            ModelsIds = new List<Guid>();
            ColorsIds = new List<Guid>();
            VendorsIds = new List<Guid>();
            RegionsIds = new List<Guid>();
            OptionsIds = new List<Guid>();
            BodyTypesIds = new List<Guid>();
            GenerationsIds = new List<Guid>();
            BodyTypeGroupsIds = new List<Guid>();
            RangePower = new RangePower(0, 0);
            RangePrice = new RangePrice(0, 0);
            RangeMileage = new RangeMileage(0, 0);
            RangePowerKvt = new RangePowerKvt(0, 0);
            RangeFuelRate = new RangeFuelRate(0, 0);
            RangeCreatedAt = new RangeCreatedAt(DateTime.MinValue, DateTime.MaxValue);
            RangeDoorsCount = new RangeDoorsCount(0, 0);
            RangeOwnersNumber = new RangeOwnersNumber(0, 0);
            RangeAcceleration = new RangeAcceleration(0, 0);
            RangeDisplacement = new RangeDisplacement(0, 0);
            RangeClearanceMin = new RangeClearanceMin(0, 0);
            RangeTrunkVolumeMin = new RangeTrunkVolume(0, 0);
            RangeTrunkVolumeMax = new RangeTrunkVolume(0, 0);
            Limits = new List<int>()
            {
                5, 10, 15, 20, 25, 50, 100
            };
            WarrantyValues = new Dictionary<bool?, string>()
            {
                { true, "Есть" },
                { false, "Нету" }
            };
            IsBeatenValues = new Dictionary<bool?, string>()
            {
                { true, "Да" },
                { false, "Нет" }
            };
            IsOriginalValues = new Dictionary<bool?, string>()
            {
                { true, "Да" },
                { false, "Нет" }
            };
            SortingOptions = new Dictionary<SortingOption, string>()
            {
                { SortingOption.Default, "Сортировка по умолчанию" },
                { SortingOption.ByAscendingName, "Сортировка по названию: от А до Я" },
                { SortingOption.ByDescendingName, "Сортировка по названию: от Я до А" }
            };
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
