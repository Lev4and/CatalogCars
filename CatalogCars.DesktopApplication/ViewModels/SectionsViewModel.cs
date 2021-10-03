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
    public class SectionsViewModel : BindableBase
    {
        private readonly SectionsRequester _sectionsRequester;

        public Pagination Pagination { get; set; }

        public SectionsFilters Filters { get; set; }

        public ObservableCollection<string> NamesSections { get; set; }

        public ObservableCollection<Section> Sections { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesSectionsAsync();
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

        public SectionsViewModel()
        {
            _sectionsRequester = new SectionsRequester();
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
                CountTotalItems = (await _sectionsRequester.GetCountSectionsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new SectionsFilters();

            await ResetPaginationAsync();
            await GetNamesSectionsAsync();
            await SearchAsync();
        }

        private async Task GetNamesSectionsAsync()
        {
            NamesSections = new ObservableCollection<string>((await _sectionsRequester.GetNamesSectionsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Sections = new ObservableCollection<Section>((await _sectionsRequester.GetSectionsAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var sections = await _sectionsRequester.GetSectionsAsync(Filters);

                    foreach (var section in sections)
                    {
                        Sections.Add(section);
                    }
                }
            }
        }
    }
}
