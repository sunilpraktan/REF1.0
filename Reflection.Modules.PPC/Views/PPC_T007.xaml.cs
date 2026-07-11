using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.PPC.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.PPC.Views
{
    /// <summary>
    /// Interaction logic for PPC_T005.xaml
    /// </summary>
    public partial class PPC_T007 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public PPC_T007(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PPC_T005_VM(ts_code, "04");
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PPC_T007(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PPC_T005_VM(ts_code, "04", doc_no);
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
                ppOrderNo.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != ppOrderNo)
            {
                //var msg = new NotificationMessage(ts_code_vm);
                //this.Dispatcher.BeginInvoke((Action)(() =>
                //{
                //    NotificationMessageReceived(msg);
                //}));
                //e.Handled = true;
            }
        }
    }
}
