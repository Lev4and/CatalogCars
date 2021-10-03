﻿using CatalogCars.Model.Database.AuxiliaryTypes;
using Entities = CatalogCars.Model.Database.Entities;
using CatalogCars.Resource.Requests.HttpRequesters;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class SellersViewModel : BindableBase
    {
        private readonly RegionsRequester _regionsRequester;
        private readonly SellersRequester _sellersRequester;

        public Pagination Pagination { get; set; }

        public SellersFilters Filters { get; set; }

        public Pagination RegionsPagination { get; set; }

        public RegionsFilters RegionsFilters { get; set; }

        public ObservableCollection<string> NamesSellers { get; set; }

        public ObservableCollection<Entities.Seller> Sellers { get; set; }

        public ObservableCollection<Entities.RegionInformation> Regions { get; set; }

        public ICommand RegionsScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return RegionsLoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand ScrollViewerChanged => new AsyncCommand<object>((obj) =>
        {
            return LoadAsync(obj as ScrollChangedEventArgs);
        });

        public ICommand SearchStringChanged => new AsyncCommand(() =>
        {
            return GetNamesSellersAsync();
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

        public SellersViewModel()
        {
            _regionsRequester = new RegionsRequester();
            _sellersRequester = new SellersRequester();
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
                CountTotalItems = (await _sellersRequester.GetCountSellersAsync(Filters))
            };
        }

        private async Task ResetRegionsPaginationAsync()
        {
            RegionsPagination = new Pagination()
            {
                NumberPage = Filters.NumberPage,
                ItemsPerPage = Filters.ItemsPerPage,
                CountTotalItems = (await _regionsRequester.GetCountRegionsAsync(RegionsFilters))
            };
        }

        private async Task ResetAsync()
        {
            Filters = new SellersFilters();
            RegionsFilters = new RegionsFilters();

            await ResetPaginationAsync();
            await ResetRegionsPaginationAsync();

            await GetNamesSellersAsync();

            await SearchAsync();
            await SearchRegionsAsync();
        }

        private async Task GetNamesSellersAsync()
        {
            NamesSellers = new ObservableCollection<string>((await _sellersRequester.GetNamesSellersAsync(Filters.SearchString)).ToList());
        }

        private async Task SearchAsync()
        {
            Filters.ResetForSearch();

            await ResetPaginationAsync();

            Sellers = new ObservableCollection<Entities.Seller>((await _sellersRequester.GetSellersAsync(Filters)).ToList());
        }

        private async Task SearchRegionsAsync()
        {
            RegionsFilters.ResetForSearch();

            await ResetRegionsPaginationAsync();

            Regions = new ObservableCollection<Entities.RegionInformation>((await _regionsRequester.GetRegionsAsync(RegionsFilters)).ToList());
        }

        private async Task RegionsLoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (RegionsPagination.NumberPage < RegionsPagination.MaxNumberPage)
                {
                    RegionsFilters.NumberPage += 1;
                    RegionsPagination.NumberPage += 1;

                    var regions = await _regionsRequester.GetRegionsAsync(RegionsFilters);

                    foreach (var region in regions)
                    {
                        Regions.Add(region);
                    }
                }
            }
        }

        private async Task LoadAsync(ScrollChangedEventArgs eventArgs)
        {
            if ((int)(eventArgs.VerticalOffset / (eventArgs.ExtentHeight - eventArgs.ViewportHeight) * 100) >= 80)
            {
                if (Pagination.NumberPage < Pagination.MaxNumberPage)
                {
                    Filters.NumberPage += 1;
                    Pagination.NumberPage += 1;

                    var sellers = await _sellersRequester.GetSellersAsync(Filters);

                    foreach (var seller in sellers)
                    {
                        Sellers.Add(seller);
                    }
                }
            }
        }
    }
}
