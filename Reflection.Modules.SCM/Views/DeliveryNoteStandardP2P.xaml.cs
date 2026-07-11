using System;
using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using Reflection.Presentation.Services;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for DeliveryNoteStandardP2P.xaml
    /// </summary>
    public partial class DeliveryNoteStandardP2P : WindowElement
    {
        private bool isManualEditCommit;
        private string ts_code_local;
        public DeliveryNoteStandardP2P(string ts_code)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new LOG_T001_A_STD_VM("DT",ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public DeliveryNoteStandardP2P(string doc_no, string ts_code, string ts_name_display,string doc_type)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new LOG_T001_A_STD_VM("DT", ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public DeliveryNoteStandardP2P(string doc_no, string ts_code, string ts_name_display)
        {
            this.ts_code_local = ts_code;
            AppSessionState.ViewTitle = ts_name_display;
            InitializeComponent();
            this.DataContext = new LOG_T001_A_STD_VM("DT", ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
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
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage(this.ts_code_local);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == this.ts_code_local)
            {
                popSupplingplant.IsOpen = false;
                popTransporter.IsOpen = false;
                popTR_Mode.IsOpen = false;
                popWtUOM.IsOpen = false;
                popVolUOM.IsOpen = false;
                popReceivingPlant.IsOpen = false;
                popFilterSearch.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popWtUOM)
            {
                var msg = new NotificationMessage(this.ts_code_local);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
