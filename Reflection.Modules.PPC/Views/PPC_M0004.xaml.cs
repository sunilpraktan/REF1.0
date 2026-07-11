using System;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.PPC.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;

namespace Reflection.Modules.PPC.Views
{
    /// <summary>
    /// Interaction logic for PPC_M0004.xaml
    /// </summary>
    public partial class PPC_M0004 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public PPC_M0004(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new PPC_M0004_VM(ts_code, "RN", "R");
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PPC_M0004(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PPC_M0004_VM(ts_code, "RN", "R", doc_no);
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
