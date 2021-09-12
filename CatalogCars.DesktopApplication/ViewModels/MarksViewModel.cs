using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpRequesters;
using DevExpress.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class MarksViewModel : BindableBase
    {
        private readonly MarksRequester _marksRequester;

        public MarksFilters Filters { get; set; }

        public Pagination Pagination { get; set; }

        public Dictionary<SortingOption, string> SortingOptions { get; set; }

        public ObservableCollection<string> NamesMarks { get; set; }

        public ObservableCollection<Mark> Marks { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesMarksAsync();
        });

        public ICommand Search => new AsyncCommand(() =>
        {
            return SearchAsync();
        });

        public ICommand Reset => new AsyncCommand(() =>
        {
            return ResetAsync();
        });

        public ICommand Info => new AsyncCommand(() =>
        {
            return new Task(() => { });
        });

        public MarksViewModel()
        {
            _marksRequester = new MarksRequester();

            SortingOptions = new Dictionary<SortingOption, string>()
            {
                { SortingOption.Default, "Сортировка по умолчанию" },
                { SortingOption.ByAscendingName, "Сортировка по названию: от А до Я" },
                { SortingOption.ByDescendingName, "Сортировка по названию: от Я до А" }
            };

            ResetAsync();
        }

        private async Task ResetPaginationAsync()
        {
            Pagination = new Pagination()
            {
                NumberPage = Filters.NumberPage,
                ItemsPerPage = Filters.ItemsPerPage,
                CountTotalItems = (await _marksRequester.GetCountMarks(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new MarksFilters();

            await ResetPaginationAsync();
            await GetNamesMarksAsync();
            await SearchAsync();
        }

        private async Task GetNamesMarksAsync()
        {
            NamesMarks = new ObservableCollection<string>((await _marksRequester.GetNamesMarks(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Marks = new ObservableCollection<Mark>((await _marksRequester.GetMarksAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var marks = await _marksRequester.GetMarksAsync(Filters);

                    foreach (var mark in marks)
                    {
                        Marks.Add(mark);
                    }
                }
            }
        }
    }
}
