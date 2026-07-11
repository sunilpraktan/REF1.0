using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for InstrumentMaster.xaml
    /// </summary>
    public partial class InstrumentMaster : WindowElement
    {
        public InstrumentMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new QMS_M003_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public InstrumentMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new QMS_M003_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "QMS_M003_VM")
            {
                popup_ItemCode.IsOpen = false;
                popup_CatCode.IsOpen = false;
                popup_Employee.IsOpen = false;
                popup_InstLab.IsOpen = false;
                popup_InvNo.IsOpen = false;
                popup_MasterInst.IsOpen = false;
                popup_PoNo.IsOpen = false;
                popup_ReqNo.IsOpen = false;
                popup_Rig.IsOpen = false;
                popup_SubCatCode.IsOpen = false;
                popup_Supplier.IsOpen = false;
                popup_Tracibility.IsOpen = false;                
            }
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
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popup_CatCode)
            {
                var msg = new NotificationMessage("QMS_M003_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
