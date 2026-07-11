using System.Windows;
using System.Windows.Controls;
using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for Sorting.xaml
    /// </summary>
    public partial class Sorting_2 : WindowElement
    {
        public Sorting_2(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ESO_T001_VM_2(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public Sorting_2(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ESO_T001_VM_2(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ESO_T001_VM_2")
            {
                //BarcodePopup.IsOpen = false;
                MachinePopup.IsOpen = false;
                ShiftPopup.IsOpen = false;
                UnitPopup.IsOpen = false;
                popupoperator.IsOpen = false;
                UnitPopup.IsOpen = false;
                ShiftinchargePopup.IsOpen = false;
                _popupGrade.IsOpen = false;
               
                _popup_status.IsOpen = false;
            }
        }
        private void dgPopupItems_Unloaded(object sender, RoutedEventArgs e)
        {
            dgbarcode.UnselectAll();
            dgData.UnselectAll();
            dgMachine.UnselectAll();
            dgOperator.UnselectAll();
            dgshift.UnselectAll();
            dgShiftIncharge.UnselectAll();
            dgUOM.UnselectAll();
            dgOperator.UnselectAll();


            e.Handled = true;
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
        
    }
}
