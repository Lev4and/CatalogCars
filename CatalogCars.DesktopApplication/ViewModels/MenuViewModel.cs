using CatalogCars.DesktopApplication.Services;
using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Pages = CatalogCars.DesktopApplication.Views.Pages;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class MenuViewModel : BindableBase
    {
        private readonly MenuPageService _menuPageService;

        public bool IsLeftDrawerOpen { get; set; }

        public Page PageSource { get; set; }

        public MenuViewModel(MenuPageService menuPageService)
        {
            _menuPageService = menuPageService;
            _menuPageService.OnPageChanged += (page) => { IsLeftDrawerOpen = false; PageSource = page; };
        }

        public ICommand OnUnchecked => new DelegateCommand(() =>
        {
            IsLeftDrawerOpen = false;
        });

        public ICommand Announcements => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Announcements.Announcements());
        });

        public ICommand AnnouncementsOnline => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Announcements.AnnouncementsOnline());
        });

        public ICommand AnnouncementsOnlineSearch => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Announcements.AnnouncementsOnlineSearch());
        });

        public ICommand AnnouncementsOnlineSearchSave => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Announcements.AnnouncementsOnlineSearchSave());
        });

        public ICommand Marks => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Marks.Marks());
        });

        public ICommand Models => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Models.Models());
        });

        public ICommand Generations => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Generations.Generations());
        });

        public ICommand Regions => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Regions.Regions());
        });

        public ICommand Locations => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Locations.Locations());
        });

        public ICommand Availabilities => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Availabilities.Availabilities());
        });

        public ICommand BodyTypeGroups => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.BodyTypeGroups.BodyTypeGroups());
        });

        public ICommand BodyTypes => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.BodyTypes.BodyTypes());
        });

        public ICommand Categories => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Categories.Categories());
        });

        public ICommand Colors => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Colors.Colors());
        });

        public ICommand ColorTypes => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.ColorTypes.ColorTypes());
        });

        public ICommand Coordinates => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Coordinates.Coordinates());
        });

        public ICommand Currencies => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Currencies.Currencies());
        });

        public ICommand EngineTypes => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.EngineTypes.EngineTypes());
        });

        public ICommand GearTypes => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.GearTypes.GearTypes());
        });

        public ICommand Options => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Options.Options());
        });

        public ICommand Phones => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Phones.Phones());
        });

        public ICommand PhotoClasses => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.PhotoClasses.PhotoClasses());
        });

        public ICommand PriceSegments => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.PriceSegments.PriceSegments());
        });

        public ICommand PtsTypes => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.PtsTypes.PtsTypes());
        });

        public ICommand Salons => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Salons.Salons());
        });

        public ICommand Sections => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Sections.Sections());
        });

        public ICommand Sellers => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Sellers.Sellers());
        });

        public ICommand SellerTypes => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.SellerTypes.SellerTypes());
        });

        public ICommand Statuses => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Statuses.Statuses());
        });

        public ICommand SteeringWheels => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.SteeringWheels.SteeringWheels());
        });

        public ICommand Tags => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Tags.Tags());
        });

        public ICommand Transmissions => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Transmissions.Transmissions());
        });

        public ICommand Vendors => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.Vendors.Vendors());
        });

        public ICommand VinResolutions => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.VinResolutions.VinResolutions());
        });

        public ICommand ImportCars => new DelegateCommand(() =>
        {
            _menuPageService.ChangePage(new Pages.ImportCars.ImportCars());
        }, () => true);

        public ICommand Exit => new DelegateCommand(() =>
        {
            Application.Current.Shutdown();
        });
    }
}
