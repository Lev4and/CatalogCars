using CatalogCars.Model.Formatters.String;
using System;
using System.Collections.Generic;

namespace CatalogCars.Model.Database.AuxiliaryTypes
{
    public class Pagination
    {
        private int _countTotalItems;

        public int NumberPage { get; set; }

        public int ItemsPerPage { get; set; }

        public int MaxNumberPage { get; private set; }

        public int CountTotalItems
        {
            get { return _countTotalItems; }
            set
            {
                _countTotalItems = value;

                OnCountTotalItemsChanged();
            }
        }

        private void OnCountTotalItemsChanged()
        {
            MaxNumberPage = (CountTotalItems % ItemsPerPage != 0 ? (CountTotalItems / ItemsPerPage) + 1 : CountTotalItems / ItemsPerPage);
        }

        private List<int> GetRange(int start, int end)
        {
            var length = Math.Abs(end - start) + 1;
            var result = new List<int>();

            for (int i = 0; i < length; i++)
            {
                result.Add(i * Math.Sign(end - start) + start);
            }

            return result;
        }

        public string GetFormattedStringRange()
        {
            var from = 0;
            var to = 0;

            if (CountTotalItems > 0)
            {
                from = 1;
                to = NumberPage * ItemsPerPage <= CountTotalItems ? NumberPage * ItemsPerPage : CountTotalItems;
            }
            else
            {
                from = 0;
                to = 0;
            }

            return $"Показаны {from}-{to} из {CountTotalItems} {Declension.DeclensionByNumeral(CountTotalItems, new string[3] { "результата", "результатов", "результатов" }, false)}";
        }

        public List<int> GeneratePagination()
        {
            var pagination = new List<int>();

            var centerLeft = 0;
            var centerRight = 0;

            var leftSideCount = 1;
            var rightSideCount = 1;
            var centerSideCount = 2;

            pagination.AddRange(GetRange(1, leftSideCount));

            if (MaxNumberPage >= 3)
            {
                centerLeft = Math.Max(leftSideCount + 1, NumberPage - centerSideCount);
                centerRight = Math.Min(MaxNumberPage - rightSideCount, centerLeft + centerSideCount * 2);
                centerLeft = Math.Max(leftSideCount + 1, centerRight - centerSideCount * 2);

                pagination.AddRange(GetRange(centerLeft, centerRight));
            }

            if (MaxNumberPage > 1)
            {
                pagination.AddRange(GetRange(MaxNumberPage - rightSideCount + 1, MaxNumberPage));
            }

            return pagination;
        }
    }
}
