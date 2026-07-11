using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.MM.ViewModels;
using System;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;
using Reflection.BusinessEntity;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_T001.xaml
    /// </summary>
    public partial class MM_T020 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
       
        public MM_T020(string ts_code,STD_LIST_BE STD_OBJ)
        {
            ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new MM_T020_VM(STD_OBJ);
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
                var msg = new NotificationMessage(this.ts_code_vm);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == this.ts_code_vm)
            {

            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popDummy)
            {
                var msg = new NotificationMessage(this.ts_code_vm);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
