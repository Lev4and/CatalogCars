using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class BodyTypeGroup
    {
        [Display(Name = "Уникальный идентификатор")]
        public Guid Id { get; set; }

        [Display(Name = "Наименование")]
        public string Name { get; set; }

        [Display(Name = "Русское наименование")]
        public string RuName { get; set; }

        [MaxLength(1)]
        [Display(Name = "Класс")]
        public string AutoClass { get; set; }

        [Display(Name = "Типы автомобильных кузовов")]
        public virtual ICollection<BodyType> BodyTypes { get; set; }
    }
}
