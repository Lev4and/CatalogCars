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
    public class TagsViewModel : BindableBase
    {
        private readonly TagsRequester _tagsRequester;

        public Pagination Pagination { get; set; }

        public TagsFilters Filters { get; set; }

        public ObservableCollection<string> NamesTags { get; set; }

        public ObservableCollection<Tag> Tags { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesTagsAsync();
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

        public TagsViewModel()
        {
            _tagsRequester = new TagsRequester();
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
                CountTotalItems = (await _tagsRequester.GetCountTagsAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new TagsFilters();

            await ResetPaginationAsync();
            await GetNamesTagsAsync();
            await SearchAsync();
        }

        private async Task GetNamesTagsAsync()
        {
            NamesTags = new ObservableCollection<string>((await _tagsRequester.GetNamesTagsAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Tags = new ObservableCollection<Tag>((await _tagsRequester.GetTagsAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var tags = await _tagsRequester.GetTagsAsync(Filters);

                    foreach (var tag in tags)
                    {
                        Tags.Add(tag);
                    }
                }
            }
        }
    }
}
