using System;
using System.Collections.Generic;
using System.Windows;
using Reflection.Presentation.Core.Navigation;
using NLog;
using Reflection.Shell.Authentication;
using Microsoft.Practices.ServiceLocation;
using Reflection.Shell.ViewModel;
using Reflection.Shell.Views;
using Reflection.Presentation.Services;
using System.Windows.Media;
using System.Windows.Interop;
using System.Windows.Threading;

namespace Reflection.Shell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            //DispatcherHelper.Initialize(); comment by sunil. Method does not support in MVVM 5.3.0.0 version.
        }
        
        #region · Logger ·

        private static Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region · Static Members ·

        /// <summary>
        /// Determines if the application is running on Windows 7
        /// </summary>
        public static bool RunningOnWin7
        {
            get
            {
                return (Environment.OSVersion.Version.Major > 6) ||
                    (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor >= 1);
            }
        }

        #endregion

        #region · Fields ·

        
        private List<string> pendingNavigations;
        private string[] args;
        private bool isLoggedIn;

        #endregion

        #region · Methods ·

        public void Run(string[] arguments)
        {
            this.args = arguments;

            this.Run();
        }

        #endregion

        #region · Overriden Methods ·
        LoginView window = new LoginView();
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            RenderOptions.ProcessRenderMode = RenderMode.Default; // NOTE: added on 09/07/2023 for performance improvement of Popup control.
            //////////////////////////////////////////////////////////////////////////////
            LoginViewModel vm = new LoginViewModel();
            this.window = new LoginView();
            vm.RequestClose += new EventHandler<EventArgs>(CloseWindow);
            vm.RequestLogin += new EventHandler<EventArgs>(LoginTryWindow);
            this.window.DataContext = vm;
            this.window.ShowDialog();

            if (AppSessionState.IsUserLogin == false)
            {
                Application.Current.Shutdown();
            }
            //////////////////////////////////////////////////////////////////////////////
            var app = (App)Application.Current;
            app.ChangeTheme(new Uri("/Reflection.Presentation.Resources;component/" + AppSessionState.UserTheme, UriKind.RelativeOrAbsolute));
        }

        public ResourceDictionary ThemeDictionary
        {
            // You could probably get it via its name with some query logic as well.
            get { return Resources.MergedDictionaries[0]; }
        }

        public void ChangeTheme(Uri uri)
        {
            try
            {
                if (ThemeDictionary.MergedDictionaries.Count > 0)
                {
                    ThemeDictionary.MergedDictionaries.Clear();
                }
                ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
            }
            catch(Exception ex)
            { }
        }
        #endregion

        /////////////////////////////////////////////////////////////////
        public void CloseWindow(Object source, EventArgs args)
        {
            if (AppSessionState.IsUserLogin == false)
            {
                this.window.Close();
            }

        }
        public void LoginTryWindow(Object source, EventArgs args)
        {
            if (AppSessionState.IsUserLogin == false && AppSessionState.LoginCount < 2)
            {
                AppSessionState.LoginCount = AppSessionState.LoginCount + 1;
            }
            else if (AppSessionState.IsUserLogin == false && AppSessionState.LoginCount >= 2)
            {
                this.window.Close();
            }
            else if (AppSessionState.IsUserLogin == true)
            {
                this.window.Close();
            }

        }
        /////////////////////////////////////////////////////////////////

        #region · Observer Actions ·

        private void OnAuthenticationAction(AuthenticationInfo info)
        {
            switch (info.Action)
            {
                case AuthenticationAction.LogOn:
                    this.isLoggedIn = false;
                    break;

                case AuthenticationAction.LoggedIn:
                    this.isLoggedIn = true;

                    if (this.pendingNavigations != null &&
                        this.pendingNavigations.Count > 0)
                    {
                        this.ProcessPendingNavigations();
                    }
                    break;

                case AuthenticationAction.LogOut:
                    this.isLoggedIn = false;
                    break;
            }
        }

        #endregion

        #region · Private Methods ·

        private void ProcessPendingNavigations()
        {
            foreach (string url in this.pendingNavigations)
            {
                ServiceLocator.Current.GetInstance<INavigationService>().Navigate(url);
            }
        }

        #endregion

        #region · Event Handlers ·
        private void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            // NOTE: this DataGrid Collection error not yet resolved and it catch in this Handlere. => EditItem is not allowed for this view - exception has been thrown by the target of an invocation
            // Log or display the exception information
            //MessageBox.Show($"Exception: {e.Exception}");
            Logger.ErrorException("Unmanaged exception", e.Exception);

            e.Handled = true;
        }

        //private void OnSingleInstanceActivated(object sender, SingleInstanceEventArgs e)
        //{
        //    if (e != null && e.Args != null && e.Args.Count > 1)
        //    {
        //        ServiceLocator.Current.GetInstance<INavigationService>().Navigate(e.Args[1]);
        //    }
        //}

        #endregion
    }
}
