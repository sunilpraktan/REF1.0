using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_T014.xaml
    /// </summary>
    public partial class SDM_T014 : WindowElement
    {
        private string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public SDM_T014(string ts_code)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            this.DataContext = new SDM_T005_VM(ts_code, "RE", "RE", ts_code);//NOTE: SDM_T008_VM not using right now, we will use single VM for all screen for same table.
        }
        public SDM_T014(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            this.DataContext = new SDM_T005_VM(ts_code, "RE", "RE", doc_no);
        }
        public SDM_T014(string ts_code, STD_LIST_BE STD_OBJECT)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T005_VM(ts_code, STD_OBJECT);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                ppRefDoc.IsOpen = false;
                popFilterSearch.IsOpen = false;
            }
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

    }
}
