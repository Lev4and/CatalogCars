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
    public class VendorsViewModel : BindableBase
    {
        private readonly VendorsRequester _vendorsRequester;

        public Pagination Pagination { get; set; }

        public VendorsFilters Filters { get; set; }

        public ObservableCollection<string> NamesVendors { get; set; }

        public ObservableCollection<Vendor> Vendors { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesVendorsAsync();
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

        public VendorsViewModel()
        {
            _vendorsRequester = new VendorsRequester();
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
                CountTotalItems = (await _vendorsRequester.GetCountVendorsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new VendorsFilters();

            await ResetPaginationAsync();
            await GetNamesVendorsAsync();
            await SearchAsync();
        }

        private async Task GetNamesVendorsAsync()
        {
            NamesVendors = new ObservableCollection<string>((await _vendorsRequester.GetNamesVendorsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Vendors = new ObservableCollection<Vendor>((await _vendorsRequester.GetVendorsAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var vendors = await _vendorsRequester.GetVendorsAsync(Filters);

                    foreach (var vendor in vendors)
                    {
                        Vendors.Add(vendor);
                    }
                }
            }
        }
    }
}
