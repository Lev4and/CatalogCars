﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CatalogCars.Model.Database.Entities
{
    public class PriceSegment
    {
        [Display(Name = "Уникальный идентификатор")]
        public Guid Id { get; set; }

        [Display(Name = "Наименование")]
        [Required(ErrorMessage = "Не указано наименование")]
        public string Name { get; set; }

        [Display(Name = "Русское наименование")]
        [Required(ErrorMessage = "Не указано русское наименование")]
        public string RuName { get; set; }

        [Display(Name = "Поколения")]
        public virtual ICollection<Generation> Generations { get; set; }
    }
}
