using System.Diagnostics;

namespace TestStack.White.WebBrowser
{
    public static class InternetExplorer
    {
        public static InternetExplorerWindow Launch(string url, string title)
        {
            var application = LaunchApplication(url);
            return GetWindow(application, title);
        }

        public static InternetExplorerWindow GetWindow(Application application, string title)
        {
            return (InternetExplorerWindow) application.GetWindow(title);
        }

        public static Application LaunchApplication(string url)
        {
            InternetExplorerFactory.Plugin();
            var processStartInfo = new ProcessStartInfo {FileName = "iexplore.exe", Arguments = url};

            return Application.Launch(processStartInfo);
        }
    }
}