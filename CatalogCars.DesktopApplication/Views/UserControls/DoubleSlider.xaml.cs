using System.Windows;
using System.Windows.Controls;

namespace CatalogCars.DesktopApplication.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для DoubleSlider.xaml
    /// </summary>
    public partial class DoubleSlider : UserControl
    {
        public bool IsSnapToTickEnabled
        {
            get { return (bool)GetValue(IsSnapToTickEnabledProperty); }
            set { SetValue(IsSnapToTickEnabledProperty, value); }
        }

        public static readonly DependencyProperty IsSnapToTickEnabledProperty =
            DependencyProperty.Register("IsSnapToTickEnabled", typeof(bool), typeof(DoubleSlider), new PropertyMetadata(false));

        public double MinValue
        {
            get { return (double)GetValue(MinValueProperty); }
            set { SetValue(MinValueProperty, value); BeginValue = value; }
        }

        public static readonly DependencyProperty MinValueProperty =
            DependencyProperty.Register("MinValue", typeof(double), typeof(DoubleSlider), new PropertyMetadata(0d));

        public double BeginValue
        {
            get { return (double)GetValue(BeginValueProperty); }
            set { SetValue(BeginValueProperty, value); }
        }

        public static readonly DependencyProperty BeginValueProperty =
            DependencyProperty.Register("BeginValue", typeof(double), typeof(DoubleSlider), new PropertyMetadata(0d));

        public double EndValue
        {
            get { return (double)GetValue(EndValueProperty); }
            set { SetValue(EndValueProperty, value); }
        }

        public static readonly DependencyProperty EndValueProperty =
            DependencyProperty.Register("EndValue", typeof(double), typeof(DoubleSlider), new PropertyMetadata(1d));

        public double MaxValue
        {
            get { return (double)GetValue(MaxValueProperty); }
            set { SetValue(MaxValueProperty, value); EndValue = value; }
        }

        public static readonly DependencyProperty MaxValueProperty =
            DependencyProperty.Register("MaxValue", typeof(double), typeof(DoubleSlider), new PropertyMetadata(1d));

        public double TickFrequency
        {
            get { return (double)GetValue(TickFrequencyProperty); }
            set { SetValue(TickFrequencyProperty, value); }
        }

        public static readonly DependencyProperty TickFrequencyProperty =
            DependencyProperty.Register("TickFrequency", typeof(double), typeof(DoubleSlider), new PropertyMetadata(1d));

        public DoubleSlider()
        {
            InitializeComponent();
        }
    }
}
