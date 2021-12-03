using System;

namespace CatalogCars.Model.Database.AnonymousTypes
{
    public class PopularMark
    {
        public Guid Id { get; set; }
        
        public int Count { get; set; }

        public string Name { get; set; }

        public string Logo { get; set; }

    }
}
