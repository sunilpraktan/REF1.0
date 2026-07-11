using System;
using System.Windows.Controls;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.QMS;
using System.Windows.Input;

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for QMS_T013.xaml
    /// </summary>
    public partial class QMS_T013 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public QMS_T013(string ts_code, QMS_T003 lot_info, string defect_level)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new QMS_T003_DR_VM(ts_code, lot_info, defect_level);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public QMS_T013(string ts_code, QMS_T003 lot_info, string defect_level, QMS_T003_A char_info)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new QMS_T003_DR_VM(ts_code, lot_info, defect_level, char_info);
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
                //popOperation_No.IsOpen = false;
            }
        }
        
    }
}
