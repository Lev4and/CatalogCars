using CatalogCars.Model.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class AnnouncementsFilters : IFilters
    {
        [DisplayName("Гарантия")]
        public bool? Warranty { get; set; }

        [DisplayName("Битая ли?")]
        public bool? IsBeaten { get; set; }

        [DisplayName("Оригинальный ПТС")]
        public bool? IsOriginal { get; set; }

        [DisplayName("Номер страницы")]
        public int NumberPage { get; set; }

        [DisplayName("Максимальный радиус поиска")]
        public int MaxSearchRadius => 20100;

        [DisplayName("Зона поиска (км)")]
        public int SearchRadius { get; set; }

        [DisplayName("Показывать по")]
        public int ItemsPerPage { get; set; }

        [DisplayName("Строка поиска")]
        public string SearchString { get; set; }

        [DisplayName("Сортировать по")]
        public SortingOption SortingOption { get; set; }

        [DisplayName("Статус")]
        public Guid? StatusId { get; set; }

        [DisplayName("Раздел")]
        public Guid? SectionId { get; set; }

        [DisplayName("Валюта")]
        public Guid? CurrencyId { get; set; }

        [DisplayName("Тип привода")]
        public Guid? GearTypeId { get; set; }

        [DisplayName("Тип двигателя")]
        public Guid? EngineTypeId { get; set; }

        [DisplayName("Тип продавца")]
        public Guid? SellerTypeId { get; set; }

        [DisplayName("Трансмиссия")]
        public Guid? TransmissionId { get; set; }

        [DisplayName("Вид доступности")]
        public Guid? AvailabilityId { get; set; }

        [DisplayName("Вид рулевого колеса")]
        public Guid? SteeringWheelId { get; set; }

        [DisplayName("Год выпуска")]
        public RangeYear RangeYear { get; set; }

        [DisplayName("Мощность")]
        public RangePower RangePower { get; set; }

        [DisplayName("Стоимость")]
        public RangePrice RangePrice { get; set; }

        [DisplayName("Регион")]
        public RegionInformation Region { get; set; }

        [DisplayName("Пробег")]
        public RangeMileage RangeMileage { get; set; }

        [DisplayName("Мощность кВт")]
        public RangePowerKvt RangePowerKvt { get; set; }

        [DisplayName("Расход топлива")]
        public RangeFuelRate RangeFuelRate { get; set; }

        [DisplayName("Дата публикации")]
        public RangeCreatedAt RangeCreatedAt { get; set; }

        [DisplayName("Кол-во дверей")]
        public RangeDoorsCount RangeDoorsCount { get; set; }

        [DisplayName("Кол-во владельцев")]
        public RangeOwnersNumber RangeOwnersNumber { get; set; }

        [DisplayName("Разгон до 100 Км/ч (сек)")]
        public RangeAcceleration RangeAcceleration { get; set; }

        [DisplayName("Объём двигателя")]
        public RangeDisplacement RangeDisplacement { get; set; }

        [DisplayName("Минимальный зазор")]
        public RangeClearanceMin RangeClearanceMin { get; set; }

        [DisplayName("Объём багажника (MIN)")]
        public RangeTrunkVolume RangeTrunkVolumeMin { get; set; }

        [DisplayName("Объём багажника (MAX)")]
        public RangeTrunkVolume RangeTrunkVolumeMax { get; set; }

        [DisplayName("Лимиты")]
        public List<int> Limits { get; set; }

        [DisplayName("Теги")]
        public List<Guid> TagsIds { get; set; }

        [DisplayName("Марки")]
        public List<Guid> MarksIds { get; set; }

        [DisplayName("Модели")]
        public List<Guid> ModelsIds { get; set; }

        [DisplayName("Цвета")]
        public List<Guid> ColorsIds { get; set; }

        [DisplayName("Производители")]
        public List<Guid> VendorsIds { get; set; }

        [DisplayName("Регионы")]
        public List<Guid> RegionsIds { get; set; }

        [DisplayName("Опции")]
        public List<Guid> OptionsIds { get; set; }

        [DisplayName("Типы кузова")]
        public List<Guid> BodyTypesIds { get; set; }

        [DisplayName("Поколения")]
        public List<Guid> GenerationsIds { get; set; }

        [DisplayName("Классы кузова")]
        public List<Guid> BodyTypeGroupsIds { get; set; }

        [DisplayName("Значения гарантии")]
        public Dictionary<bool?, string> WarrantyValues { get; set; }

        [DisplayName("Значения состояния автомобиля")]
        public Dictionary<bool?, string> IsBeatenValues { get; set; }

        [DisplayName("Значения оригинальности ПТС")]
        public Dictionary<bool?, string> IsOriginalValues { get; set; }

        [DisplayName("Типы сортировки")]
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
            SearchRadius = MaxSearchRadius;
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
            Region = null;
            RangeYear = new RangeYear(0, 0);
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
                { SortingOption.ByDescendingName, "Сортировка по названию: от Я до А" },
                { SortingOption.ByAscendingCreationDate, "Сортировка по возрастанию даты публикации" },
                { SortingOption.ByDescendingCreationDate, "Сортировка по убыванию даты публикации" },
                { SortingOption.ByAscendingUpdateDate, "Сортировка по возрастанию даты обновления" },
                { SortingOption.ByDescendingUpdateDate, "Сортировка по убыванию даты обновления" },
                { SortingOption.ByAscendingPrice, "Сортировка по возрастанию стоимости" },
                { SortingOption.ByDescendingPrice, "Сортировка по убыванию стоимости" },
                { SortingOption.ByAscendingYear, "Сортировка по возрастанию года выпуска" },
                { SortingOption.ByDescendingYear, "Сортировка по убыванию года выпуска" },
                { SortingOption.ByAscendingMileage, "Сортировка по возрастанию пробега" },
                { SortingOption.ByDescendingMileage, "Сортировка по убыванию пробега" }
            };
        }

        public void ResetForSearch()
        {
            NumberPage = 1;
        }
    }
}
