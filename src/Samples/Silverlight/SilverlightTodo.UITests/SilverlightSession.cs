using System;
using System.IO;
using TestStack.White.Configuration;
using TestStack.White.ScreenObjects.Services;
using TestStack.White.ScreenObjects.Sessions;
using TestStack.White.WebBrowser;
using TestStack.White.WebBrowser.Silverlight;

namespace SilverlightTodo.UITests
{
    // TODO: maybe move to TestStack.White.WebBrowser.Silverlight ?
    public class SilverlightSession : IDisposable
    {
        bool _initalized;
        SimpleHost _simpleHost;

        public SilverlightDocument Document
        {
            get { return _simpleHost.FindSilverlightDocument(); }
        }
        
        public void Open(string url, string windowTitle)
        {
            CoreAppXmlConfiguration.Instance.FindWindowTimeout = 3000;
            
            _simpleHost = SimpleHost.Launch(url, windowTitle);
            
            var workConfig = new WorkConfiguration
            {
                ArchiveLocation = Path.GetDirectoryName(GetType().Assembly.Location),
                Name = windowTitle
            };
            var nullEnv = new NullWorkEnvironment();

            var workSession = new WorkSession(workConfig, nullEnv);
            workSession.Attach(_simpleHost.Application);
        }

        public void Close()
        {
            if (_simpleHost == null) return;
            if (_simpleHost.Application != null) _simpleHost.Application.Close();
        }

        public void Dispose()
        {
            Close();
        }

        public void Initialize(Action action)
        {
            if (_initalized || action == null) return;

            action.Invoke();
            _initalized = true;
        }
    }
}