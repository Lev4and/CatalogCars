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
    public class CategoriesViewModel : BindableBase
    {
        private readonly CategoriesRequester _categoriesRequester;

        public Pagination Pagination { get; set; }

        public CategoriesFilters Filters { get; set; }

        public ObservableCollection<Category> Categories { get; set; }

        public ObservableCollection<string> NamesCategories { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesCategoriesAsync();
        });

        public ICommand Loaded => new AsyncCommand(() =>
        {
            return LoadedAsync();
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

        public CategoriesViewModel()
        {
            _categoriesRequester = new CategoriesRequester();
        }

        private async Task LoadedAsync()
        {
            await ResetAsync();
        }

        private async Task ResetPaginationAsync()
        {
            Pagination = new Pagination()
            {
                NumberPage = Filters.NumberPage,
                ItemsPerPage = Filters.ItemsPerPage,
                CountTotalItems = (await _categoriesRequester.GetCountCategoriesAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new CategoriesFilters();

            await ResetPaginationAsync();
            await GetNamesCategoriesAsync();
            await SearchAsync();
        }

        private async Task GetNamesCategoriesAsync()
        {
            NamesCategories = new ObservableCollection<string>((await _categoriesRequester.GetNamesCategoriesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Categories = new ObservableCollection<Category>((await _categoriesRequester.GetCategoriesAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var categories = await _categoriesRequester.GetCategoriesAsync(Filters);

                    foreach (var category in categories)
                    {
                        Categories.Add(category);
                    }
                }
            }
        }
    }
}
