using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;

namespace TestStack.White.WebBrowser.SimpleBrowser
{
    // Straight from StackOverflow: http://stackoverflow.com/a/265648/385507
    public static class WebBrowserUtility
    {
        public static readonly DependencyProperty BindableSourceProperty =
            DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(WebBrowserUtility), new UIPropertyMetadata(null, BindableSourcePropertyChanged));

        public static string GetBindableSource(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSourceProperty);
        }

        public static void SetBindableSource(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }

        public static void BindableSourcePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var browser = sender as System.Windows.Controls.WebBrowser;
            if (browser == null) return;
            try
            {
                string location = e.NewValue as string;
                browser.Source = location.CreateValidWebUrl();
            }
            catch(Exception ex)
            {
                // HACK
                Console.WriteLine("Error when trying to apply new location:\n{0}", ex);
                Debug.WriteLine("Error when trying to apply new location:\n{0}", ex);
            }
        }

        public static Uri CreateValidWebUrl(this string location)
        {
            if (Path.IsPathRooted(location))
            {
                location = String.Format("file:///{0}", location.Replace("\\", "/"));
            }

            if (!Regex.IsMatch(location, "^\\w+:(//|\\w+)"))
            {
                location = String.Format("http://{0}", location);
            }

            Debug.WriteLine(String.Format("Trying to create URI from: {0}", location));
            return new Uri(location, UriKind.RelativeOrAbsolute);
        }
    }
}