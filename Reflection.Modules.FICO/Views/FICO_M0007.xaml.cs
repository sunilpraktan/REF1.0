using System;
using System.Windows;
using System.Windows.Controls;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_M0027.xaml
    /// </summary>
    public partial class FICO_M0007 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public FICO_M0007(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new FICO_M0007_VM(ts_code);
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster.SelectionChanged += TabControl_SelectionChanged;
            
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ACC_M003_A_VM")
            {
                _popupGrp_Cat.IsOpen = false;
                _popupcoa_key.IsOpen = false;
                _popupPGCode_key.IsOpen = false;
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("ACC_M003_A_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
