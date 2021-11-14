using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class Color
    {
        [Display(Name = "Уникальный идентификатор")]
        public Guid Id { get; set; }

        [MaxLength(6)]
        [Display(Name = "Значение")]
        [Required(ErrorMessage = "Не указано значение")]
        public string Value { get; set; }

        [Display(Name = "Объявления")]
        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
