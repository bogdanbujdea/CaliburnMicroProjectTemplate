using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CaliburnUniversalTemplate.Views
{
    public sealed partial class MainPageView : Page
    {
        public MainPageView()
        {
            InitializeComponent();
            Loaded += ViewLoaded;
        }

        private void ViewLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if ( Window.Current.Bounds.Width < 1024 )
                ButtonsPanel.Orientation = Orientation.Vertical;
        }
    }
}