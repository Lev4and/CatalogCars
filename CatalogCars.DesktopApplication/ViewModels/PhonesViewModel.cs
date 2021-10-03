﻿using CatalogCars.Model.Database.AuxiliaryTypes;
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
    public class PhonesViewModel : BindableBase
    {
        private readonly PhonesRequester _phonesRequester;

        public Pagination Pagination { get; set; }

        public PhonesFilters Filters { get; set; }

        public ObservableCollection<string> NamesPhones { get; set; }

        public ObservableCollection<Phone> Phones { get; set; }

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesPhonesAsync();
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

        public PhonesViewModel()
        {
            _phonesRequester = new PhonesRequester();
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
                CountTotalItems = (await _phonesRequester.GetCountPhonesAsync(Filters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new PhonesFilters();

            await ResetPaginationAsync();
            await GetNamesPhonesAsync();
            await SearchAsync();
        }

        private async Task GetNamesPhonesAsync()
        {
            NamesPhones = new ObservableCollection<string>((await _phonesRequester.GetNamesPhonesAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Phones = new ObservableCollection<Phone>((await _phonesRequester.GetPhonesAsync(Filters)).ToList());
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var phones = await _phonesRequester.GetPhonesAsync(Filters);

                    foreach (var phone in phones)
                    {
                        Phones.Add(phone);
                    }
                }
            }
        }
    }
}
