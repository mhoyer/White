using System.Collections.Generic;
using CommandLine;

namespace TestStack.White.WebBrowser.SimpleBrowser
{
    public class Options
    {
        [Option('w', "width", DefaultValue = 1024, HelpText = "The initial screen width of the host.")]
        public int Width { get; set; }

        [Option('h', "height", DefaultValue = 768, HelpText = "The initial screen height of the host.")]
        public int Height { get; set; }

        [Option('l', "left", DefaultValue = null, HelpText = "The initial left position of the window.")]
        public int? Left { get; set; }

        [Option('t', "top", DefaultValue = null, HelpText = "The initial top position of the window.")]
        public int? Top { get; set; }
        
        [Option("title", DefaultValue = "SimpleHost", HelpText = "The window title.")]
        public string Title { get; set; }

        [ValueList(typeof(List<string>), MaximumElements = 1)]
        public IList<string> Locations { get; set; }
    }
}