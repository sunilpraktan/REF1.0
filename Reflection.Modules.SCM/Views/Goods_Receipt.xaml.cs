using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for Goods_Receipt.xaml
    /// </summary>
    public partial class Goods_Receipt : WindowElement
    {
        public Goods_Receipt(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_AVM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public Goods_Receipt(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_AVM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            Rindentpopup.IsOpen = false;
            popup_movtype.IsOpen = false;
            popup_req.IsOpen = false;
            popup_dept.IsOpen = false;
            popup_po.IsOpen = false;
            popup_pg.IsOpen = false;
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
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // dgPopupMvType.UnselectAll();
                // dgPopupEmp.UnselectAll();
                //// dgPopupPlant.UnselectAll();
                // dgPopupDept.UnselectAll();            
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgParameters_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void dgPopupMvType_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupMvType.UnselectAll();
            }
            catch
            {

            }
            e.Handled = true;
        }

        
    }
}
