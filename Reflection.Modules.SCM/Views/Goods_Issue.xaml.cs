using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for Goods_Issue.xaml
    /// </summary>
    public partial class Goods_Issue : WindowElement
    {
        public Goods_Issue(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public Goods_Issue(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_VM(ts_code,doc_no);
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
            if (msg.Notification == "MM_T001_VM")
            {
                movepopup.IsOpen = false;
                reqpopup.IsOpen = false;
                orderpopup.IsOpen = false;
                deptpopup.IsOpen = false;
                indentpopup.IsOpen = false;
                deptloc.IsOpen = false;
                deptcomp.IsOpen = false; 
            }
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ////dgPopupMvType.UnselectAll();
                //dgPopupEmp.UnselectAll();
                ////dgPopupPlant.UnselectAll();
                //dgPopupDept.UnselectAll();

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

        private void dgPopupIndentNo_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupIndentNo.UnselectAll();                

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void WindowElement_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != IndentNo_PopUp)
            {
                var msg = new NotificationMessage("MM_T001_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
