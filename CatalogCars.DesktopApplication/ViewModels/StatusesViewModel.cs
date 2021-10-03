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
    public class StatusesViewModel : BindableBase
    {
        private readonly StatusesRequester _StatusesRequester;

        public Pagination Pagination { get; set; }

        public StatusesFilters Filters { get; set; }

        public ObservableCollection<string> NamesStatuses { get; set; }

        public ObservableCollection<Status> Statuses { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesStatusesAsync();
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

        public StatusesViewModel()
        {
            _StatusesRequester = new StatusesRequester();
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
                CountTotalItems = (await _StatusesRequester.GetCountStatusesAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new StatusesFilters();

            await ResetPaginationAsync();
            await GetNamesStatusesAsync();
            await SearchAsync();
        }

        private async Task GetNamesStatusesAsync()
        {
            NamesStatuses = new ObservableCollection<string>((await _StatusesRequester.GetNamesStatusesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Statuses = new ObservableCollection<Status>((await _StatusesRequester.GetStatusesAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var statuses = await _StatusesRequester.GetStatusesAsync(Filters);

                    foreach (var status in statuses)
                    {
                        Statuses.Add(status);
                    }
                }
            }
        }
    }
}
