using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_M0001.xaml
    /// </summary>
    public partial class SDM_M0016 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public SDM_M0016(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new SDM_M0016_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            //Tbmaster.SelectionChanged += TabControl_SelectionChanged;
            InitializeComponent();
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ADM_M028_H_VM")
            {
                _popupPartyID.IsOpen = false;
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("ADM_M028_H_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
