using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using TestStack.White.Factory;
using TestStack.White.WebBrowser.Silverlight;

namespace TestStack.White.WebBrowser
{
    public class SimpleHost
    {
        readonly string _windowTitle;
        readonly InitializeOption _initializeOption;
        SilverlightDocument _silverlightDocument;

        public Application Application { get; set; }
        public SimpleHostWindow Window { get; set; }
        
        public SimpleHost(Application application, string windowTitle, bool enableCaching = true)
        {
            _windowTitle = windowTitle;
            _initializeOption = InitializeOption.NoCache;
            if (enableCaching) _initializeOption = _initializeOption.AndIdentifiedBy(_windowTitle);

            Application = application;
            FindWindow();
        }

        public static SimpleHost Launch(string url, string windowTitle, 
            int? width = null, int? height = null,
            int? top = null, int? left = null,
            bool enableCaching = true)
        {
            SimpleHostFactory.Plugin();

            var argsBuilder = new StringBuilder(String.Format("--title \"{0}\" ", windowTitle));
            if (width.HasValue) argsBuilder.Append(" -w ").Append(width);
            if (height.HasValue) argsBuilder.Append(" -h ").Append(height);
            if (top.HasValue) argsBuilder.Append(" -t ").Append(top);
            if (left.HasValue) argsBuilder.Append(" -l ").Append(left);
            argsBuilder.Append(String.Format(" -u \"{0}\"", url));

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
            
            return new SimpleHost(application, windowTitle, enableCaching);
        }

        public void NavigateTo(string url)
        {
            Window.Location = url;
        }

        public SilverlightDocument FindSilverlightDocument(bool force = false)
        {
            if (_silverlightDocument == null || force)
            {
                FindWindow();
                _silverlightDocument = Window.SilverlightDocument;
            }

            return _silverlightDocument;
        }

        void FindWindow()
        {
            Window = (SimpleHostWindow)Application.GetWindow(_windowTitle, _initializeOption);
        }
    }
}