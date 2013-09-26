namespace TestStack.White.WebBrowser.SimpleBrowser
{
    public class MainWindowPresenter
    {
        public MainWindowModel Model { get; set; }
        public IMainWindow Window { get; set; }

        public MainWindowPresenter(IMainWindow window, MainWindowModel model)
        {
            Model = model;
            Window = window;
            Window.Loaded += Initialize;
        }

        void Initialize()
        {
            Window.Loaded -= Initialize;

            Window.Title = Model.Options.Title;
            Window.SetViewPort(Model.Options.Width, Model.Options.Height);
            Window.MoveWindowTo(Model.Options.Top, Model.Options.Left);
            Window.NavigateTo(Model.Options.Url);
        }
    }
}