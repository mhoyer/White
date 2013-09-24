using System.Windows;

namespace TestStack.White.WebBrowser.SimpleBrowser
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            Loaded += OnMainWindowLoaded;
        }

        void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            if (App.Options.Left.HasValue) Left = App.Options.Left.Value;
            if (App.Options.Top.HasValue) Top = App.Options.Top.Value;
        }
    }
}
