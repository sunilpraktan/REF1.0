using System;
using System.Windows;
using System.Windows.Input;
using Reflection.Shell.ViewModel;
using WinInterop = System.Windows.Interop;
using Reflection.Presentation.Common;
using System.ComponentModel;
using System.Windows.Controls;
using Reflection.Presentation.Services;

namespace Reflection.Shell
{
    /// <summary>
    /// Interaction logic for MainShell.xaml
    /// </summary>
    public partial class MainShell : Window
    {
        private UserControl _UC_OBJ = new UserControl();
        public UserControl UC_OBJ
        {
            get { return _UC_OBJ; }
            set
            {
                if (_UC_OBJ != value)
                {
                    _UC_OBJ = value; RaisePropertyChanged("UC_OBJ");

                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
            //ValidateAsync(); NOTE: Temparary Commented
            //bool msg = this.HasErrors; NOTE: Temparary Commented
        }

        public MainShell()
        {
            try
            {
                InitializeComponent();
                LoadInvoice();
                Closing += (s, e) => ViewModelLocator.Cleanup();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error, MessageBoxResult.Cancel, MessageBoxOptions.ServiceNotification);
            }
        }

        #region · Event Handlers ·

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (e.SystemKey == Key.Space && e.Key == Key.System)
            {
                // Disable Window's ControlBox Menu
                e.Handled = true;
            }

            base.OnPreviewKeyDown(e);
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);

            IntPtr handle = (new WinInterop.WindowInteropHelper(this)).Handle;
            WinInterop.HwndSource.FromHwnd(handle).AddHook(new WinInterop.HwndSourceHook(Win32Interop.WindowProc));

            //ShellViewModel vm = new ShellViewModel();
            //vm.WindowState = System.Windows.WindowState.Maximized;

            //this.DataContext = vm;

        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_contacts.Visibility = Visibility.Collapsed;
                tt_messages.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_messages.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            //img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            //img_bg.Opacity = 0.3;
        }

        #endregion
        //private void btnCustomer_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        if (Mouse.OverrideCursor == null)
        //        {
        //            CursorControl.SetBusyState();

        //            AppSessionState.ViewTitle = "New Account";
        //            AppSessionState.TransactionCode = "SD101";

        //            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.SDM.dll"); // this one is path option
        //            Assembly assembly = Assembly.LoadFile(path1);
        //            Type type = assembly.GetType("Reflection.Modules.SDM.Views.SDM_M0021");
        //            if (type != null)
        //            {
        //                dynamic instance = Activator.CreateInstance(type, AppSessionState.TransactionCode);
        //                SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
        //            }
        //            e.Handled = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        #region Functions
        private void LoadInvoice()
        {
            UC_OBJ = new Reflection.Modules.FICO.Views.FICO_U0001("FI21");
            ccWorkspace.Content = UC_OBJ;
            //UC_OBJ.DataContext = new PMS_T005_VM("RS05", "PL", OBJ_TEMP);
            //UC_OBJ = new Reflection.Modules.PMS.Views.PMS_T005();
            //UC_OBJ.DataContext = new PMS_T005_VM("RS05", "PL", OBJ_TEMP);
        }
        #endregion
    }
}
