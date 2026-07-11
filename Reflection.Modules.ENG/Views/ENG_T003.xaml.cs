using System;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.ENG.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;

namespace Reflection.Modules.ENG.Views
{
    public partial class ENG_T003 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public ENG_T003(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new ENG_T001_VM(ts_code, "BM");
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public ENG_T003(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new ENG_T001_VM(ts_code, "BM", doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
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

                //ppBomCat.IsOpen = false;

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
