using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace TestStack.White.WebBrowser
{
    public class SimpleHost
    {
        public Application Application { get; set; }
        public SimpleHostWindow Window { get; set; }

        SimpleHost(Application application, SimpleHostWindow window)
        {
            Application = application;
            Window = window;
        }

        public static SimpleHost Launch(string url, string windowTitle, 
            int? width = null, int? height = null,
            int? top = null, int? left = null)
        {
            SimpleHostFactory.Plugin();

            var argsBuilder = new StringBuilder(String.Format("--title \"{0}\" ", windowTitle));
            if (width.HasValue) argsBuilder.Append(" -w ").Append(width);
            if (height.HasValue) argsBuilder.Append(" -h ").Append(height);
            if (top.HasValue) argsBuilder.Append(" -t ").Append(top);
            if (left.HasValue) argsBuilder.Append(" -l ").Append(left);
            argsBuilder.Append(String.Format("\"{0}\"", url));

            var processStartInfo = new ProcessStartInfo
            {
                FileName = typeof(SimpleBrowser.Identifiers).Assembly.Location,
                Arguments = argsBuilder.ToString()
            };

            if (!File.Exists(processStartInfo.FileName))
            {
                throw new FileNotFoundException("Required", processStartInfo.FileName);
            }

            var application = Application.Launch(processStartInfo);
            var window = (SimpleHostWindow)application.GetWindow(windowTitle);
            
            return new SimpleHost(application, window);
        }

    }
}