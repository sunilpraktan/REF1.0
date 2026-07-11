using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_M0001.xaml
    /// </summary>
    public partial class SDM_M0005 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public SDM_M0005(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new SDM_M0005_VM(ts_code);
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "SDM_M0005_VM")
            {
                _popupState.IsOpen = false;
                _popupCountry.IsOpen = false;

            }

        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("SDM_M0005_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
