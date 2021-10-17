using CatalogCars.DesktopApplication.Services;
using CatalogCars.Model.Database.AuxiliaryTypes;
using CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpRequesters;
using DevExpress.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using Pages = CatalogCars.DesktopApplication.Views.Pages;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class MarksViewModel : BindableBase
    {
        private readonly MenuPageService _menuPageService;
        private readonly MarksRequester _marksRequester;

        public Guid? SelectedMarkId { get; set; }

        public MarksFilters Filters { get; set; }

        public Pagination Pagination { get; set; }

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
            return OnClickInfo();
        }, () => SelectedMarkId != null);

        public MarksViewModel(MenuPageService menuPageService)
        {
            _menuPageService = menuPageService;
            _marksRequester = new MarksRequester();
        }

        private async Task OnClickInfo()
        {
            _menuPageService.ChangePage(new Pages.Marks.Info((Guid)SelectedMarkId));
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
                CountTotalItems = (await _marksRequester.GetCountMarksAsync(Filters))
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
            NamesMarks = new ObservableCollection<string>((await _marksRequester.GetNamesMarksAsync(Filters.SearchString)).ToList());
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
