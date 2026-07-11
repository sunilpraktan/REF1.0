using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SDM.Views
{
    public partial class SDM_T015 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        private string ts_code_local;

        public SDM_T015(string ts_code)
        {
            ts_code_vm = ts_code;
            ts_code_vm = ts_code;
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T011_VM("ID", ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T015(string ts_code, string doc_no)
        {
            ts_code_vm = ts_code;
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T011_VM("ID", ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T015(string doc_no, string ts_code, string ts_name_display)
        {
            ts_code_vm = ts_code;
            this.ts_code_local = ts_code;
            AppSessionState.ViewTitle = ts_name_display;
            InitializeComponent();
            this.DataContext = new SDM_T011_VM("ID", ts_code, doc_no, "GO");
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
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                popFilterSearch.IsOpen = false;
                PopSoDetail.IsOpen = false;
            }
        }
    }
}
