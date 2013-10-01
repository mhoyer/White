using System;
using System.Windows.Automation;
using TestStack.White.AutomationElementSearch;
using TestStack.White.Configuration;
using TestStack.White.Factory;
using TestStack.White.Sessions;
using TestStack.White.UIItems;
using TestStack.White.Utility;
using TestStack.White.WebBrowser.SimpleBrowser;

namespace TestStack.White.WebBrowser
{
    public class SimpleHostWindow : BrowserWindow
    {
        TextBox _locationBar;

        public string Location
        {
            get { return LocationBar.Text; }
            set { LocationBar.Enter(String.Format("{0}\n", value)); }
        }
        
        private TextBox LocationBar
        {
            get { return FindLocationBar(); }
        }

        public SimpleHostWindow(AutomationElement automationElement, WindowFactory windowFactory, InitializeOption option, WindowSession windowSession)
            : base(automationElement, windowFactory, option, windowSession) {}
        
        private TextBox FindLocationBar()
        {
            if (_locationBar != null) return _locationBar;

            var finder = new AutomationElementFinder(AutomationElement);
            var locationBar = Retry.For(
                () =>
                {
                    var automationSearchCondition = AutomationSearchCondition
                        .ByControlType(ControlType.Edit)
                        .WithAutomationId(Identifiers.LocationBar);

                    return finder.Descendant(automationSearchCondition);
                },
                CoreAppXmlConfiguration.Instance.BusyTimeout());

            if (locationBar == null)
            {
                var message = string.Format("Could not find LocationBar after waiting for {0}. " +
                                            "Timeout value configured by BusyTimeout in White/Core",
                    CoreAppXmlConfiguration.Instance.BusyTimeout);
                throw new UIItemSearchException(message);
            }

            _locationBar = new TextBox(locationBar, this);

            return _locationBar;
        }
    }
}