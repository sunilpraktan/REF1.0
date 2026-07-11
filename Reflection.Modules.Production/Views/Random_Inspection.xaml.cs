using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.Production.ViewModels;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for Random_Inspection.xaml
    /// </summary>
    public partial class Random_Inspection : WindowElement
    {
        public Random_Inspection(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ZCRM_T002_RI_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public Random_Inspection(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ZCRM_T002_RI_VM(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            dgbarcode.UnselectAll();
            
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

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ZCRM_T002_RI_VM")
            {
                machinepopup.IsOpen = false;
                unitpopup.IsOpen = false;
                shiftpopup.IsOpen = false;
                otherpopup.IsOpen = false;
                shiftinchargepop.IsOpen = false;
                qcpopup.IsOpen = false;
                _popup_status.IsOpen = false;

            }
        }
        
    }
}
