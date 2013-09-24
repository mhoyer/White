using System.Linq;

namespace TestStack.White.WebBrowser.SimpleBrowser
{
    public class MainWindowViewModel
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }

        public MainWindowViewModel()
        {
            Width = App.Options.Width;
            Height = App.Options.Height;
            Location = App.Options.Locations.FirstOrDefault();
            Title = App.Options.Title;
        }
    }
}