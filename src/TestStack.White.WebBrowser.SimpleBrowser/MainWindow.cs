using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestStack.White.WebBrowser.SimpleBrowser
{
    public interface IMainWindow
    {
        void MoveWindowTo(int? left, int? top);
        void NavigateTo(string location);
        void SetViewPort(int width, int height);
        event Action Loaded;
        string Title { get; set; }
    }

    public partial class MainWindow : Form, IMainWindow
    {
        public event Action Loaded;
        public string Title 
        {
            get { return Text; }
            set { Text = value; }
        }

        public MainWindow()
        {
            InitializeComponent();
            Name = Identifiers.Window;

            browser.Navigated += (sender, args) => locationBar.Text = args.Url.ToString();
            Load += OnLoad;
        }

        void OnLoad(object sender, EventArgs e)
        {
            if (Loaded != null) Loaded();
            Load -= OnLoad;
        }

        public void NavigateTo(string location)
        {
            browser.Navigate(location);
        }

        public void SetViewPort(int width, int height)
        {
            var borderWidth = Width - browser.Width;
            var borderHeight = Height - browser.Height;
            Width = width + borderWidth;
            Height = height + borderHeight;
        }

        public void MoveWindowTo(int? left, int? top)
        {
            var x = left ?? Location.X;
            var y = top ?? Location.Y;
            
            Location = new Point(x, y);
        }

        private void LocationBar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                NavigateTo(locationBar.Text);
            }
        }
    }
}
