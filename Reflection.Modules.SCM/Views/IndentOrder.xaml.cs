using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.SCM.ViewModels;
using System;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Description for IndentOrder.
    /// </summary>
    public partial class IndentOrder : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the IndentOrder class.
        /// </summary>
        public IndentOrder(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_T003_A_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
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
            if (msg.Notification == "MM_T003_VM")
            {
                doctypepopup.IsOpen = false;
                prioritypopup.IsOpen = false;
                bompopup.IsOpen = false;
                reqpopup.IsOpen = false;
                deptpopup.IsOpen = false;
                deptcomp.IsOpen = false;
                deptloc.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != doctypepopup)
            {
                var msg = new NotificationMessage("MM_T003_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        
    }
}