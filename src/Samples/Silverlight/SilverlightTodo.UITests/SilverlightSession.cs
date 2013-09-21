using System;
using System.IO;
using TestStack.White;
using TestStack.White.ScreenObjects.Services;
using TestStack.White.ScreenObjects.Sessions;
using TestStack.White.WebBrowser;
using TestStack.White.WebBrowser.Silverlight;

namespace SilverlightTodo.UITests
{
    // TODO: maybe move to TestStack.White.WebBrowser.Silverlight ?
    public class SilverlightSession : IDisposable
    {
        Application Application { get; set; }
        BrowserWindow BrowserWindow { get; set; }
        WorkSession WorkSession { get; set; }

        bool _initalized;

        public SilverlightDocument Document
        {
            get { return BrowserWindow.SilverlightDocument; }
        }
        
        public void Open(string url, string windowTitle)
        {
            Close(); // to prevent multiple browser windows

            var ieWindowTitle = String.Format("{0} - Windows Internet Explorer", windowTitle);

            Application = InternetExplorer.LaunchApplication(url);
            BrowserWindow = InternetExplorer.GetWindow(Application, ieWindowTitle);
            
            var workConfig = new WorkConfiguration
            {
                ArchiveLocation = Path.GetDirectoryName(GetType().Assembly.Location),
                Name = windowTitle
            };
            var nullEnv = new NullWorkEnvironment();

            WorkSession = new WorkSession(workConfig, nullEnv);
            WorkSession.Attach(Application);
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (WorkSession != null) WorkSession.Dispose();
            if (BrowserWindow != null) BrowserWindow.Dispose();
            if (Application != null) Application.Dispose();
        }

        public void Initialize(Action action)
        {
            if (_initalized || action == null) return;

            action.Invoke();
            _initalized = true;
        }
    }
}