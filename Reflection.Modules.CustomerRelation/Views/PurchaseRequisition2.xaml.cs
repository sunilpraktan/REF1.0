using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for PurchaseRequisition2.xaml
    /// </summary>
    public partial class PurchaseRequisition2 : WindowElement
    {
        public PurchaseRequisition2(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PUR_T001_A_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PurchaseRequisition2(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PUR_T001_A_VM(ts_code, doc_no);
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
            if (msg.Notification == "PUR_T001_A_VM")
            {
                prioritypopup.IsOpen = false;
                emppopup.IsOpen = false;
                _popup_status.IsOpen = false;
                popup_PurGrp.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != prioritypopup)
            {
                var msg = new NotificationMessage("PUR_T001_A_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void dgPopupPriority_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //prioritypopup.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupEmp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //emppopup.UnselectAll();
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

        private void Popup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //prioritypopup.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }

        private void Popup_Unloaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //PART_Selector.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;


        }
        
    }
}
