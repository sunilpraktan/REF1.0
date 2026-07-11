using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_T001.xaml
    /// </summary>
    public partial class SDM_T007 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public SDM_T007(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new SDM_T007_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T007(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new SDM_T007_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T007(string doc_no, string ts_code, string ts_name_display)
        {
            AppSessionState.ViewTitle = ts_name_display;
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new SDM_T007_VM(doc_no, ts_code, ts_name_display);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                _popupTransporter.IsOpen = false;
                _popup_status.IsOpen = false;
                _popuplocation_Id.IsOpen = false;
                _popupShippingMode.IsOpen = false;
                PopSoDetail.IsOpen = false;
                popFilterSearch.IsOpen = false;
            }
        }

        private bool isManualEditCommit;

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
    }
}
