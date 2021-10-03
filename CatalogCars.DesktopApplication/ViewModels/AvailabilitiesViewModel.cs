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
    public class AvailabilitiesViewModel : BindableBase
    {
        private readonly AvailabilitiesRequester _availabilitiesRequester;

        public Pagination Pagination { get; set; }

        public AvailabilitiesFilters Filters { get; set; }

        public ObservableCollection<Availability> Availabilities { get; set; }

        public ObservableCollection<string> NamesAvailabilities { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesAvailabilitiesAsync();
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

        public AvailabilitiesViewModel()
        {
            _availabilitiesRequester = new AvailabilitiesRequester();
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
                CountTotalItems = (await _availabilitiesRequester.GetCountAvailabilitiesAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new AvailabilitiesFilters();

            await ResetPaginationAsync();
            await GetNamesAvailabilitiesAsync();
            await SearchAsync();
        }

        private async Task GetNamesAvailabilitiesAsync()
        {
            NamesAvailabilities = new ObservableCollection<string>((await _availabilitiesRequester.GetNamesAvailabilitiesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Availabilities = new ObservableCollection<Availability>((await _availabilitiesRequester.GetAvailabilitiesAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var availabilities = await _availabilitiesRequester.GetAvailabilitiesAsync(Filters);

                    foreach (var availability in availabilities)
                    {
                        Availabilities.Add(availability);
                    }
                }
            }
        }
    }
}
