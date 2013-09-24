using System.Windows.Automation;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.WebBrowser
{
    public class SimpleHostFactory : SpecializedWindowFactory
    {
        public static void Plugin()
        {
            WindowFactory.AddSpecializedWindowFactory(new SimpleHostFactory());
        }

        public virtual bool DoesSpecializeInThis(AutomationElement windowElement)
        {
            return windowElement.Current.AutomationId == SimpleBrowser.Identifiers.Window;
        }

        public virtual Window Create(AutomationElement automationElement, InitializeOption initializeOption, WindowSession session)
        {
            return new SimpleHostWindow(automationElement, WindowFactory.Desktop, initializeOption, session);
        }
    }
}