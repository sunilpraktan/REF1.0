/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Reflection.Shell.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Reflection.Presentation.Core.Configuration;
using Reflection.Presentation.Core.Navigation;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.ViewModel;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.ViewModel;
using Reflection.Presentation.Windows;
using Reflection.Presentation.Windows.Navigation;
using Reflection.Presentation.Windows.ViewServices;
using Reflection.Shell.Model;
using Reflection.Shell.Services;
using Reflection.Shell.WidgetLibrary;

namespace Reflection.Shell.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (GalaSoft.MvvmLight.ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();
            }

            if (!SimpleIoc.Default.IsRegistered<ShellViewModel>())
            {
                SimpleIoc.Default.Register<ShellViewModel>();
            }
            if (!SimpleIoc.Default.IsRegistered<VirtualDesktopManager>())
            {
                SimpleIoc.Default.Register<IVirtualDesktopManager, VirtualDesktopManager>();
            }
            if (!SimpleIoc.Default.IsRegistered<WidgetConfigurationService>())
            {
                SimpleIoc.Default.Register<IWidgetConfigurationService, WidgetConfigurationService>();
            }
            if (!SimpleIoc.Default.IsRegistered<WidgetLibraryView>())
            {
                SimpleIoc.Default.Register<WidgetLibraryView>();
            }
            //if (!SimpleIoc.Default.IsRegistered<WidgetViewModel>())
            //{
            //    SimpleIoc.Default.Register<WidgetViewModel>();
            //}
            if (!SimpleIoc.Default.IsRegistered<WidgetLibraryViewModel>())
            {
                SimpleIoc.Default.Register<WidgetLibraryViewModel>();
            }
            if (!SimpleIoc.Default.IsRegistered<ExternalShortcutViewModel>())
            {
                SimpleIoc.Default.Register<ExternalShortcutViewModel>();
            }
            if (!SimpleIoc.Default.IsRegistered<ShowMessageViewService>())
            {
                SimpleIoc.Default.Register<IShowMessageViewService, ShowMessageViewService>();
            }
            if (!SimpleIoc.Default.IsRegistered<NavigationService>())
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }
           
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public ShellViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ShellViewModel>();
            }
        }
        public WidgetLibraryView WLibraryView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WidgetLibraryView>();
            }
        }
        public WidgetLibraryViewModel WidgetLabView
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WidgetLibraryViewModel>();
            }
        } 
        //public IVirtualDesktopManager IVirtualDesktopManager
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<IVirtualDesktopManager>();
        //    }
        //}

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}