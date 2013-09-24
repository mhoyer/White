using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.Sessions;

namespace TestStack.White.WebBrowser
{
    public class SimpleHostWindow : BrowserWindow
    {
        protected SimpleHostWindow() { }

        public SimpleHostWindow(AutomationElement automationElement, WindowFactory windowFactory, InitializeOption option, WindowSession windowSession)
            : base(automationElement, windowFactory, option, windowSession) {}
    }
}