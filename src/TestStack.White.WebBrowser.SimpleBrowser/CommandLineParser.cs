using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestStack.White.WebBrowser.SimpleBrowser
{
    public class CommandLineParser<TOption>
    {
        readonly TOption _option;
        List<CommandLineOption> _options;

        public CommandLineParser(TOption option)
        {
            _option = option;
            _options = new List<CommandLineOption>();
        }

        public void RegisterOption<TOptionValue>(
            string name, Action<TOption, TOptionValue> setter, 
            char? shortName = null, TOptionValue defaultValue = default(TOptionValue), 
            string helpText = "")
        {
            var commandLineOption = new CommandLineOption(name, shortName, defaultValue, helpText, typeof(TOptionValue));
            commandLineOption.SetAction = v => setter.Invoke(_option, (TOptionValue)v);
            
            setter.Invoke(_option, defaultValue);

            _options.Add(commandLineOption);
        }

        public IEnumerable<string> Parse(IEnumerable<string> args)
        {
            var remainingOptions = new List<string>();

            CommandLineOption option = null;
            var shortOptionName = new Regex("^-");
            var longOptionName = new Regex("^--");

            foreach (var arg in args)
            {
                if (longOptionName.IsMatch(arg))
                {
                    option = _options.FirstOrDefault(o => ("--" + o.Name) == arg);
                    continue;
                }

                if (shortOptionName.IsMatch(arg))
                {
                    option = _options.FirstOrDefault(o => ("-" + o.ShortName) == arg);
                    continue;
                }

                if (option == null)
                {
                    remainingOptions.Add(arg);
                }
                else
                {
                    ParseAndInvoke(option, arg);
                    option = null;
                }
            }

            return remainingOptions;
        }

        void ParseAndInvoke(CommandLineOption option, string value)
        {
            option.SetAction.Invoke(Convert.ChangeType(value, option.Type));
        }
    }
}