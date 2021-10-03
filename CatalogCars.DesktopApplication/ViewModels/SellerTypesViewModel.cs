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
    public class SellerTypesViewModel : BindableBase
    {
        private readonly SellerTypesRequester _sellerTypesRequester;

        public Pagination Pagination { get; set; }

        public SellerTypesFilters Filters { get; set; }

        public ObservableCollection<string> NamesSellerTypes { get; set; }

        public ObservableCollection<SellerType> SellerTypes { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesSellerTypesAsync();
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

        public SellerTypesViewModel()
        {
            _sellerTypesRequester = new SellerTypesRequester();
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
                CountTotalItems = (await _sellerTypesRequester.GetCountSellerTypesAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new SellerTypesFilters();

            await ResetPaginationAsync();
            await GetNamesSellerTypesAsync();
            await SearchAsync();
        }

        private async Task GetNamesSellerTypesAsync()
        {
            NamesSellerTypes = new ObservableCollection<string>((await _sellerTypesRequester.GetNamesSellerTypesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            SellerTypes = new ObservableCollection<SellerType>((await _sellerTypesRequester.GetSellerTypesAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var sellerTypes = await _sellerTypesRequester.GetSellerTypesAsync(Filters);

                    foreach (var sellerType in sellerTypes)
                    {
                        SellerTypes.Add(sellerType);
                    }
                }
            }
        }
    }
}
