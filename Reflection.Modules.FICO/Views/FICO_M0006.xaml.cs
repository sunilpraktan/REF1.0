using System;
using System.Windows.Controls;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_M0027.xaml
    /// </summary>
    public partial class FICO_M0006 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public FICO_M0006(string ts_code)
        {
            
            ts_code_vm = ts_code;
            this.DataContext = new FICO_M0006_VM(ts_code);
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            
        }
        public FICO_M0006(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new FICO_M0006_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ACC_M003_VM")
            {
                _popupCurrency.IsOpen = false;
                _popupAccGrp.IsOpen = false;
                //_popupAccSub.IsOpen = false;
                _popupGrpCat.IsOpen = false;
                _popupHouseBank.IsOpen = false;
            }

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("ACC_M003_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
