using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.PPC.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.PPC.Views
{
    /// <summary>
    /// Interaction logic for ProductionOrder.xaml
    /// </summary>
    public partial class PPC_T004 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public PPC_T004(string ts_code)
        {

            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PPC_T004_VM(ts_code, "01");
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PPC_T004(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PPC_T004_VM(ts_code, "01", doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

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
                //ppRefDocument.IsOpen = false;
                //ppStatus.IsOpen = false;
                //ppDocType.IsOpen = false;
                ppItemCode.IsOpen = false;
                //ppLocationID.IsOpen = false;
                //ppPlanningPlant.IsOpen = false;
                ppUOM.IsOpen = false;
                //ppShift.IsOpen = false;
                ppEmployee.IsOpen = false;
                //ppProfitCenter.IsOpen = false;
                //ppCostCenter.IsOpen = false;
                //ppRoutingNo.IsOpen = false;
                //ppBOMNO.IsOpen = false;
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
