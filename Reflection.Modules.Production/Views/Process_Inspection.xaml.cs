using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.Production.ViewModels;
using System;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    ///Interaction logic for Process_Inspection.xaml
    ///</summary>
    public partial class Process_Inspection : WindowElement
    {
        public Process_Inspection(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ZCRM_T003_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }
        public Process_Inspection(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ZCRM_T003_VM(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }

        private void dgbarcode_Unloaded(object sender, RoutedEventArgs e)
        {
            dgRefdoctype.UnselectAll();
            dgRefdocno.UnselectAll();
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
            if (msg.Notification == "ZCRM_T003_VM")
            {
                
                shiftpopup.IsOpen = false;
                employeepopup.IsOpen = false;
                qcpopup.IsOpen = false;
                shift1popup.IsOpen = false;
                _popup_status.IsOpen = false;
                _popupGrade.IsOpen = false;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("ZCRM_T003_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
