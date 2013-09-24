using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace TestStack.White.WebBrowser.SimpleBrowser
{
    public partial class App : Application
    {
        public static Options Options { get; private set; }

        [STAThread]
        public static void Main(string[] args)
        {
            try
            {
                Options = new Options();

                CommandLine.Parser.Default.ParseArgumentsStrict(args, Options, () => OnFail(args));

                var app = new App();
                app.InitializeComponent();
                app.Run();
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
        }

        static void OnFail(string[] args)
        {
            MessageBox.Show(
                String.Format("Unable to parse command line: {0}", String.Join(" ", args)),
                "Execution error");
        }
    }
}
