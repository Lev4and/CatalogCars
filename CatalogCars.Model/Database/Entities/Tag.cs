using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Tag
    {
        [Display(Name = "Уникальный идентификатор")]
        public Guid Id { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Не указано наименование")]
        public string Name { get; set; }

        [Display(Name = "Русское наименование")]
        [Required(ErrorMessage = "Не указано русское наименование")]
        public string RuName { get; set; }

        [Display(Name = "Объявления")]
        public virtual ICollection<AnnouncementTag> Announcements { get; set; }

        [Display(Name = "Конфигурации")]
        public virtual ICollection<ConfigurationTag> Configurations { get; set; }
    }
}
