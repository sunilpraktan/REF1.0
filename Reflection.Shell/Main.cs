using System;
using NLog;
using Reflection.Presentation.Services;
using Reflection.Shell.ViewModel;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Xml.Linq ;
using System.Windows.Markup;

namespace Reflection.Shell
{
    /// <summary>
    /// Application entry point class
    /// </summary>
    public static class ChronosMain
    {
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="args">The args.</param>
        [STAThread]
        public static void Main(params string[] args)
        {
            try
            {
                var application = new App();

                application.InitializeComponent();
                CultureInfo ci = new CultureInfo("en-IN");
                ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                ci.DateTimeFormat.DateSeparator = "/";

                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
                //FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
                //XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

                if (args != null && args.Length > 0)
                {
                    application.Run(args);
                }
                else
                {

                    application.Run();
                }

                // Allow single instance code to perform cleanup operations
                //SingleInstance.Cleanup();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Exception",MessageBoxButton.OK,MessageBoxImage.Error,MessageBoxResult.Cancel,MessageBoxOptions.ServiceNotification);
            }
        }
    }
}
