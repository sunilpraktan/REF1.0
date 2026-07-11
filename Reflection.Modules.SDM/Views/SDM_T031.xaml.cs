using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_T001.xaml
    /// </summary>
    public partial class SDM_T031 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public SDM_T031(string ts_code)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T005_VM(ts_code,"OP", "OP");
            //tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T031(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T005_VM(ts_code, "OP", "OP", doc_no);
            //tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }


        private bool isManualEditCommit;

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
