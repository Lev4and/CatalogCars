using CatalogCars.DesktopApplication.Services;
using DevExpress.Mvvm;
using System.Windows.Controls;
using Pages = CatalogCars.DesktopApplication.Views.Pages;

namespace CatalogCars.DesktopApplication.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly PageService _pageService;

        public Page PageSource { get; set; }

        public MainWindowViewModel(PageService pageService)
        {
            _pageService = pageService;

            _pageService.OnPageChanged += (page) => PageSource = page;
            _pageService.ChangePage(new Pages.Menu.Menu());
        }
    }
}
