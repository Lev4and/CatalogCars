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
    public class BodyTypeGroupsViewModel : BindableBase
    {
        private readonly BodyTypeGroupsRequester _bodyTypeGroupsRequester;

        public Pagination Pagination { get; set; }

        public BodyTypeGroupsFilters Filters { get; set; }

        public ObservableCollection<BodyTypeGroup> BodyTypeGroups { get; set; }

        public ObservableCollection<string> NamesBodyTypeGroups { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesBodyTypeGroupsAsync();
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

        public BodyTypeGroupsViewModel()
        {
            _bodyTypeGroupsRequester = new BodyTypeGroupsRequester();
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
                CountTotalItems = (await _bodyTypeGroupsRequester.GetCountBodyTypeGroupsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new BodyTypeGroupsFilters();

            await ResetPaginationAsync();
            await GetNamesBodyTypeGroupsAsync();
            await SearchAsync();
        }

        private async Task GetNamesBodyTypeGroupsAsync()
        {
            NamesBodyTypeGroups = new ObservableCollection<string>((await _bodyTypeGroupsRequester.GetNamesBodyTypeGroupsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            BodyTypeGroups = new ObservableCollection<BodyTypeGroup>((await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var bodyTypeGroups = await _bodyTypeGroupsRequester.GetBodyTypeGroupsAsync(Filters);

                    foreach (var bodyTypeGroup in bodyTypeGroups)
                    {
                        BodyTypeGroups.Add(bodyTypeGroup);
                    }
                }
            }
        }
    }
}
