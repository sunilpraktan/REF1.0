using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;

namespace Reflection.Modules.ENG.Views
{

    public partial class ENG_M0011 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;

        public ENG_M0011(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            //tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //this.DataContext = new QMS_M030_I_VM(ts_code);
        }
        public ENG_M0011(string ts_code, string doc_no)
        {
            InitializeComponent();ts_code_vm = ts_code;
            ts_code_vm = ts_code;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            //tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //this.DataContext = new QMS_M030_I_VM(ts_code, doc_no);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                //PopQuali.IsOpen = false;
                //popupplant.IsOpen = false;
                //popupunit.IsOpen = false;
                //PopQuali.IsOpen = false;
            }

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage(ts_code_vm);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

    }
}
