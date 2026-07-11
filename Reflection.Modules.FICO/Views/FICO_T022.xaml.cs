using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_T001.xaml
    /// </summary>
    public partial class FICO_T022 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public FICO_T022(string ts_code)
        {

            ts_code_vm = ts_code;
            this.DataContext = new FICO_T002_VM("SI", ts_code);
            InitializeComponent();
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

        }
        public FICO_T022(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new FICO_T002_VM("SI", ts_code, doc_no);
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public FICO_T022(string ts_code, STD_LIST_BE STD_LIST_OBJ)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new FICO_T002_VM(ts_code, STD_LIST_OBJ);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
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
