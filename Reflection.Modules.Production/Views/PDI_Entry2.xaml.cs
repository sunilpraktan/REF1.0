using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for PDI_Entry2.xaml
    /// </summary>
    public partial class PDI_Entry2 : WindowElement
    {
        public PDI_Entry2(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T004_AVM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }
        public PDI_Entry2(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T004_AVM(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ECRM_T004_AVM")
            {
                barcodepopup.IsOpen = false;
                partypopup.IsOpen = false;
                shiftpopup.IsOpen = false;
                operatorpopup.IsOpen = false;
                shiftpopup.IsOpen = false;
                qc1popup.IsOpen = false;
                shift1popup.IsOpen = false;
                _popup_status.IsOpen = false;
                _popupGrade.IsOpen = false;

            }
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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("ECRM_T004_AVM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
