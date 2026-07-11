using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_T001.xaml
    /// </summary>
    public partial class SDM_T011 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        private string ts_code_local;

        public SDM_T011(string ts_code)
        {
            ts_code_vm = ts_code;
            ts_code_vm = ts_code;
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T011_VM("DN", ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T011(string ts_code, string doc_no)
        {
            ts_code_vm = ts_code;
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T011_VM("DN", ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T011(string doc_no, string ts_code, string ts_name_display)
        {
            ts_code_vm = ts_code;
            this.ts_code_local = ts_code;
            AppSessionState.ViewTitle = ts_name_display;
            InitializeComponent();
            this.DataContext = new SDM_T011_VM("DN", ts_code, doc_no, "DO");
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
                popcf_agent.IsOpen = false;
                popSupplingplant.IsOpen = false;
                popTransporter.IsOpen = false;
                popTR_Mode.IsOpen = false;
                popWtUOM.IsOpen = false;
                popVolUOM.IsOpen = false;
                popFilterSearch.IsOpen = false;
                PopSoDetail.IsOpen = false;
                PopSDDetail.IsOpen = false;
                PopMODetail.IsOpen = false;
                PopPODetail.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popcf_agent)
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
