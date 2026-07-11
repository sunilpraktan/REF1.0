using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.Navigation;
using Reflection.Presentation.Common;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Presentation.Widgets
{
    /// <summary>
    /// Interaction logic for NavigatorWidgetView.xaml
    /// </summary>
    public partial class NavigatorWidgetView : WidgetElement
    {
        private RelayCommand<string> navigatemenuCommand;
        private RelayCommand treemenuCommand;
        public NavigatorWidgetView()
        {
            InitializeComponent();
            this.DataContext = new NavigatorWidgetViewModel();
        }

        /// <summary>
        /// Gets the navigation command
        /// </summary>
        public RelayCommand<string> NavigateMenuCommand
        {
            get
            {
                if (this.navigatemenuCommand == null)
                {
                    this.navigatemenuCommand = new RelayCommand<string>((x) => OnNavigateToMenu(x));
                }

                return this.navigatemenuCommand;
            }
        }

        public RelayCommand TreeMenuCommand
        {
            get
            {
                if (this.treemenuCommand == null)
                {
                    this.treemenuCommand = new RelayCommand(() => OnNavigateToTreeMenu());
                }

                return this.treemenuCommand;
            }
        }

        private void OnNavigateToMenu(string url)
        {
            //Messagenger.Default.GetInstance<INavigationService>().Navigate(url);
            var msg = new NavigateToView() { ViewName = url };
            Messenger.Default.Send<NavigateToView>(msg);
        }
        private void OnNavigateToTreeMenu()
        {
            //Messagenger.Default.GetInstance<INavigationService>().Navigate(url);
            var msg = new NavigateToView() { ViewName = "" };
            Messenger.Default.Send<NavigateToView>(msg);
        }
        private void OnTreeNodeDoubleClick(object sender, MouseButtonEventArgs mouseEvtArgs)
        {
            try
            {
                if (Mouse.OverrideCursor == null)
                {
                    CursorControl.SetBusyState();
                    TreeViewItem item = sender as TreeViewItem;
                    DataRow row = ((System.Data.DataRowView)(item.Header)).Row;
                    List<SYS_AUTH> list = new List<SYS_AUTH>();
                    list.Add(new SYS_AUTH { menu_code = row["menu_code"].ToString(), menu_name = row["menu_name"].ToString(), menu_parent = row["menu_parent"].ToString(), ts_name = row["ts_name"].ToString(), auth_code = row["auth_code"].ToString(), location_id = row["location_id"].ToString(), ts_code = row["ts_code"].ToString(), class_file = row["class_file"].ToString(), ts_namespace = row["ts_namespace"].ToString(), ts_nspath = row["ts_nspath"].ToString() });
                    SYS_AUTH userAuth = new SYS_AUTH();
                    userAuth = list[0];
                    AppSessionState.ADM_AUTH_OBJ = userAuth;
                    AppSessionState.ViewTitle = userAuth.ts_name;
                    AppSessionState.TransactionCode = userAuth.ts_code;
                    SetAuthorisations(userAuth);
                    var msg = new NavigateToView() { ViewName = userAuth.ts_code };

                    if (userAuth.class_file != null && userAuth.class_file != "")
                    {
                        string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace); // this one is path option
                        Assembly assembly = Assembly.LoadFile(path1);
                        Type type = assembly.GetType(userAuth.class_file);
                        if (type != null)
                        {
                            dynamic instance = Activator.CreateInstance(type, userAuth.ts_code);
                            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                        }
                    }
                    mouseEvtArgs.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void SetAuthorisations(SYS_AUTH AuthData)
        {
            //AppSessionState.Add = false;
            //AppSessionState.Edit = false;
            //AppSessionState.Delete = false;
            //AppSessionState.View = false;
            //AppSessionState.Print = false;
            //AppSessionState.Mail = false;
            //foreach (var auth in AuthData.auth_code.Split(new[] { ";", "," }, StringSplitOptions.RemoveEmptyEntries))
            //{
            //    if (auth == "1")
            //    {
            //        AppSessionState.Add = true;
            //    }
            //    else if (auth == "2")
            //    {
            //        AppSessionState.Edit = true;
            //    }
            //    else if (auth == "3")
            //    {
            //        AppSessionState.Delete = true;
            //    }
            //    else if (auth == "4")
            //    {
            //        AppSessionState.View = true;
            //    }
            //    else if (auth == "5")
            //    {
            //        AppSessionState.Print = true;
            //    }
            //    else if (auth == "6")
            //    {
            //        AppSessionState.Mail = true;
            //    }

            //}
        }
    }
}
