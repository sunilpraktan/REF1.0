using System;
using System.Threading.Tasks;
using Reflection.Modules.Navigation;
using Reflection.Presentation.Core.Navigation;
using Reflection.Presentation.Core.VirtualDesktops;
using NLog;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Shell.Views;


namespace Reflection.Shell.Authentication
{
    /// <summary>
    /// Dedicated observer for authentication 
    /// </summary>
    public sealed class AuthenticationObserver : IObserver<AuthenticationInfo>
    {
        #region · Logger ·

        private static Logger Logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region · IObserver<AuthenticationInfo> Members ·

        /// <summary>
        /// Notifies the observer that the provider has finished sending push-based notifications.
        /// </summary>
        public void OnCompleted()
        {
        }

        /// <summary>
        /// Notifies the observer that the provider has experienced an error condition.
        /// </summary>
        /// <param name="error">An object that provides additional information about the error.</param>
        public void OnError(Exception error)
        {
        }

        /// <summary>
        ///  Provides the observer with new data.
        /// </summary>
        /// <param name="value">The current notification information.</param>
        public void OnNext(AuthenticationInfo value)
        {
            switch (value.Action)
            {
                case AuthenticationAction.LogOn:
                    //Logger.Debug("Autenticación del usuario");
                    //SimpleIoc.Default.GetInstance<INavigationService>()
                    //              .Navigate("0", NavigationRoutes.Login);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show<Login>();
                    break;

                case AuthenticationAction.LoggedIn:
                    Logger.Debug("Usuario autenticado correctamente");
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>()
                                  .ActivateDefaultDesktop();
                    break;

                case AuthenticationAction.LogOut:
                    Logger.Debug("Cerrando sesión");
                    Task t = Task.Factory.StartNew
                    (
                        () =>
                        {
                            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>()
                                          .CloseAll();

                            //Channel<AuthenticationInfo>.Publish
                            //(
                            //    new AuthenticationInfo
                            //    {
                            //        Action = AuthenticationAction.LogOn
                            //    },
                            //    true
                            //);
                        }
                    );
                    break;
            }
        }

        #endregion
    }
}
