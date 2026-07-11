using System;
using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using Reflection.Presentation.Services;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// NOTE: Same VM is share for SDM_T011 & SDM_T012
    /// </summary>
    public partial class SDM_T012 : WindowElement
    {
        private string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public SDM_T012(string ts_code)
        {
            ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T011_VM("DT", ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T012(string doc_no, string ts_code, string ts_name_display, string doc_type)
        {
            ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T011_VM("DT", ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T012(string doc_no, string ts_code, string ts_name_display)
        {
            ts_code_vm = ts_code;
            AppSessionState.ViewTitle = ts_name_display;
            InitializeComponent();
            this.DataContext = new SDM_T011_VM("DT", ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        //This will update the bound object whenever a cell edit is ending, i.e.whenever the cell looses focus.
        private void HandleMainDataGridCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                int x = grid.Items.Count;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                isManualEditCommit = false;
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
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                popSupplingplant.IsOpen = false;
                popTransporter.IsOpen = false;
                popTR_Mode.IsOpen = false;
                popWtUOM.IsOpen = false;
                popVolUOM.IsOpen = false;
                popReceivingPlant.IsOpen = false;
                popFilterSearch.IsOpen = false;
                PopTOItemsDetail.IsOpen = false;
                PopPODetail.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popWtUOM)
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
