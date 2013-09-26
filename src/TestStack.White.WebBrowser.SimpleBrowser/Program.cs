using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TestStack.White.WebBrowser.SimpleBrowser
{
    static class Program
    {
        [DllImport("Kernel32.dll")] public static extern bool AttachConsole(int processId);
        [DllImport("Kernel32.dll")] public static extern bool FreeConsole(int processId);

        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                AttachConsole(-1);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // bootstrap
                var options = ParseCommandLine(args);
                var model = new MainWindowModel(options);
                var window = new MainWindow();
                new MainWindowPresenter(window, model);

                Application.Run(window);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Debug.WriteLine(ex);
                MessageBox.Show(ex.Message, "Error occurred.");
            }
            finally
            {
                FreeConsole(-1);
            }
        }

        static Options ParseCommandLine(IEnumerable<string> args)
        {
            var options = new Options();

            var clp = new CommandLineParser<Options>(options);
            clp.RegisterOption("width", (o, v) => o.Width = v, 'w', 1024, helpText: "The initial screen width of the host.");
            clp.RegisterOption("height", (o, v) => o.Height = v, 'h', 768, helpText: "The initial screen height of the host.");
            clp.RegisterOption<int>("left", (o, x) => o.Left = x, 'l', helpText: "The initial left position of the window.");
            clp.RegisterOption<int>("top", (o, x) => o.Top = x, 't', helpText: "The initial top position of the window.");
            clp.RegisterOption("title", (o, x) => o.Title = x, defaultValue: "SimpleHost", helpText: "The window title.");
            clp.RegisterOption<string>("url", (o, x) => o.Url = x, 'u', helpText: "The window title.");
            clp.Parse(args);

            return options;
        }
    }
}