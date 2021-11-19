using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Currency
    {
        [Display(Name = "Уникальный идентификатор")]
        public Guid Id { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Не указано наименование")]
        public string Name { get; set; }

        [Display(Name = "Обозначение")]
        public string Designation { get; set; }

        [Display(Name = "Цены")]
        public virtual ICollection<Price> Prices { get; set; }
    }
}
