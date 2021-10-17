using System;
using System.Windows.Controls;

namespace CatalogCars.DesktopApplication.Views.Pages.Marks
{
    /// <summary>
    /// Логика взаимодействия для Info.xaml
    /// </summary>
    public partial class Info : Page
    {
        public Guid MarkId { get; set; }

        public Info(Guid markId)
        {
            MarkId = markId;

            InitializeComponent();
        }
    }
}
