using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.ENG.ViewModels;
using Reflection.Modules.PMM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.ENG.Views
{
    /// <summary>
    /// Interaction logic for Routing_Standard.xaml
    /// </summary>
    public partial class ENG_M0005 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public ENG_M0005(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new ENG_M0005_VM(ts_code, "06");
        }
        public ENG_M0005(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new ENG_M0005_VM(ts_code, "06", doc_no);
          
            


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
