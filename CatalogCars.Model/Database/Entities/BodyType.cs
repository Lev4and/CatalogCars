using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class BodyType
    {
        [Display(Name = "Уникальный идентификатор")]
        public Guid Id { get; set; }

        [Display(Name = "Класс автомобильного кузова")]
        public Guid BodyTypeGroupId { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Не указано наименование")]
        public string Name { get; set; }

        [Display(Name = "Русское наименование")]
        [Required(ErrorMessage = "Не указано русское наименование")]
        public string RuName { get; set; }

        [Display(Name = "Класс автомобильного кузова")]
        public virtual BodyTypeGroup BodyTypeGroup { get; set; }

        [Display(Name = "Конфигурации")]
        public virtual ICollection<Configuration> Configurations { get; set; }
    }
}
