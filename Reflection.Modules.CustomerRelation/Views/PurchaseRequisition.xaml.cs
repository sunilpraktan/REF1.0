using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Input;

//zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzusing System.Reflection.Modules.CustomerRelation.Modules;


namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Description for PurchaseRequisition.
    /// </summary>
    public partial class PurchaseRequisition : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the PurchaseRequisition class.
        /// </summary>
        public PurchaseRequisition(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PUR_T001_A_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PurchaseRequisition(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PUR_T001_A_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private bool isManualEditCommit;
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
            if (msg.Notification == "PUR_T001_A_VM")
            {
                prioritypopup.IsOpen = false;
                emppopup.IsOpen = false;
                _popup_status.IsOpen = false;
                popup_PurGrp.IsOpen = false;
                _popupComp.IsOpen = false;
                _popupPlant.IsOpen = false;
                deptpopup.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != prioritypopup)
            {
                var msg = new NotificationMessage("PUR_T001_A_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}