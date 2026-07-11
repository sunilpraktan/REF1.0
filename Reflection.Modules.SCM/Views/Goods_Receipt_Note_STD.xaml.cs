using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.SCM.ViewModels;
using System;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SCM.Views
{
    public partial class Goods_Receipt_Note_STD : WindowElement
    {
        private bool isManualEditCommit;
        private string ts_code_local;
        public Goods_Receipt_Note_STD(string ts_code)
        {
            InitializeComponent();
            this.ts_code_local = ts_code;
            this.DataContext = new MM_T001_STD_VM("GR",ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public Goods_Receipt_Note_STD(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.ts_code_local = ts_code;
            this.DataContext = new MM_T001_STD_VM("GR", ts_code, doc_no);
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
                popMovType.IsOpen = false;
                popTransporter.IsOpen = false;
                popTR_Mode.IsOpen = false;
                popFilterSearch.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popDummy)
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
