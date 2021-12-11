using CatalogCars.Model.Database.AuxiliaryTypes;
using System.Collections.Generic;
using System.ComponentModel;
using Entities = CatalogCars.Model.Database.Entities;

namespace CatalogCars.WebApplication.Models
{
    public class CatalogViewModel
    {
        [DisplayName("Нумерация страниц")]
        public Pagination Pagination { get; set; }

        [DisplayName("Фильтры")]
        public AnnouncementsFilters Filters { get; set; }

        [DisplayName("Теги")]
        public List<Entities.Tag> Tags { get; set; }

        [DisplayName("Марки")]
        public List<Entities.Mark> Marks { get; set; }

        [DisplayName("Модели")]
        public List<Entities.Model> Models { get; set; }

        [DisplayName("Цвета")]
        public List<Entities.Color> Colors { get; set; }

        [DisplayName("Производители")]
        public List<Entities.Vendor> Vendors { get; set; }

        [DisplayName("Опции")]
        public List<Entities.Option> Options { get; set; }

        [DisplayName("Статусы")]
        public List<Entities.Status> Statuses { get; set; }

        [DisplayName("Разделы")]
        public List<Entities.Section> Sections { get; set; }

        [DisplayName("Типы привода")]
        public List<Entities.GearType> GearTypes { get; set; }

        [DisplayName("Типы кузова")]
        public List<Entities.BodyType> BodyTypes { get; set; }

        [DisplayName("Типы двигателя")]
        public List<Entities.EngineType> EngineTypes { get; set; }

        [DisplayName("Типы продавца")]
        public List<Entities.SellerType> SellerTypes { get; set; }

        [DisplayName("Поколения")]
        public List<Entities.Generation> Generations { get; set; }

        [DisplayName("Типы трансмиссий")]
        public List<Entities.Transmission> Transmissions { get; set; }

        [DisplayName("Объявления")]
        public List<Entities.Announcement> Announcements { get; set; }

        [DisplayName("Виды доступности")]
        public List<Entities.Availability> Availabilities { get; set; }

        [DisplayName("Виды рулевого колеса")]
        public List<Entities.SteeringWheel> SteeringWheels { get; set; }

        [DisplayName("Классы кузова")]
        public List<Entities.BodyTypeGroup> BodyTypeGroups { get; set; }
    }
}
