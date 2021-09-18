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
