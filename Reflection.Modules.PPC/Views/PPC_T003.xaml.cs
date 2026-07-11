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
    public partial class PPC_T003 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public PPC_T003(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PPC_T003_VM(ts_code, "OR", "OR");
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PPC_T003(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PPC_T003_VM(ts_code, "OR", "OR", doc_no);
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
