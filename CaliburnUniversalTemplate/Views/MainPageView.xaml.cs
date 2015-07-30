namespace CaliburnUniversalTemplate.Views
{
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public sealed partial class MainPageView
    {
        public MainPageView()
        {
            InitializeComponent();
            Loaded += ViewLoaded;
            SizeChanged += ViewSizeChanged;
        }

        private void ViewSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ResizeControls();
        }

        private void ResizeControls()
        {
            if (Window.Current.Bounds.Width < 1024)
            {
                ButtonsPanel.Orientation = Orientation.Vertical;
                ShowQuestion.Margin = new Thickness(0, 10, 0, 10);
            }
            else
            {
                ButtonsPanel.Orientation = Orientation.Horizontal;
                ShowQuestion.Margin = new Thickness(10, 0, 10, 0);
            }
        }

        private void ViewLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ResizeControls();
        }
    }
}