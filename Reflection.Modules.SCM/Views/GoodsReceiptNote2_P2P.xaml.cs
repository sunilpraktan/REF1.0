using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for GoodsReceiptNote2_P2P.xaml
    /// </summary>
    public partial class GoodsReceiptNote2_P2P : WindowElement
    {
        private bool isManualEditCommit;
        private string ts_code_local;
        public GoodsReceiptNote2_P2P(string ts_code)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new MM_T001_GRN_VM2_P2P(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public GoodsReceiptNote2_P2P(string ts_code, string doc_no)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new MM_T001_GRN_VM2_P2P(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void dgrefdocno_Unloaded(object sender, RoutedEventArgs e)
        {
            dgrefdocno.UnselectAll();
            dgsendplant.UnselectAll();
            dgrecplant.UnselectAll();
            dgtransporter.UnselectAll();
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            dgsaleorgnisation.UnselectAll();
            dgPurchaseGroup.UnselectAll();
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == this.ts_code_local)
            {
                popTR_Mode.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != status_popup)
            {
                var msg = new NotificationMessage(this.ts_code_local);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

    }
}
