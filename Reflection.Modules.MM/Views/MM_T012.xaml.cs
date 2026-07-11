using System;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.MM.ViewModels;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for PMS_T002.xaml
    /// </summary>
    public partial class MM_T012 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_T012(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new MM_T012_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            InitializeComponent();
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
            if (msg.Notification == ts_code_vm)
            {
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.Source != txtStatus)
            //{
            //    var msg = new NotificationMessage("PMS_T001_VM");
            //    this.Dispatcher.BeginInvoke((Action)(() =>
            //    {
            //        NotificationMessageReceived(msg);
            //    }));
            //    e.Handled = true;
            //}
        }
    }
}
