using System;

namespace TestStack.White.WebBrowser.SimpleBrowser
{
    public class CommandLineOption
    {
        public string Name { get; set; }
        public char? ShortName { get; set; }
        public object DefaultValue { get; set; }
        public string HelpText { get; set; }
        public Type Type { get; set; }
        public Action<object> SetAction { get; set; }

        public CommandLineOption(string name, char? shortName, object defaultValue, string helpText, Type type)
        {
            ShortName = shortName;
            Name = name;
            DefaultValue = defaultValue;
            HelpText = helpText;
            Type = type;
        }
    }
}