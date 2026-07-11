using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;

namespace Reflection.Modules.QMS.Views
{

    public partial class QMS_T001 : WindowElement
    {
        public string ts_code_vm { get; set; }

        public QMS_T001(string ts_code)
        {
            InitializeComponent();
            this.ts_code_vm = ts_code;
            this.DataContext = new QMS_T003_VM(ts_code,"IL");
            //tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public QMS_T001(STD_LIST_BE OBJ_LIST)
        {
            InitializeComponent();
            this.DataContext = new QMS_T003_VM(OBJ_LIST);
            //tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == this.ts_code_vm)
            {
                
            }

        }

        //private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    if (e.Source is TabControl)
        //    {
        //        var msg = new NotificationMessage(this.ts_code_vm);
        //        this.Dispatcher.BeginInvoke((Action)(() =>
        //        {
        //            NotificationMessageReceived(msg);
        //        }));
        //        e.Handled = true;
        //    }
        //}
        
    }
}
