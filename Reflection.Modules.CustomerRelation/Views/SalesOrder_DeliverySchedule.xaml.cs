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
using Reflection.Presentation.Windows.Controls;
using Reflection.WebServices.Gateway;
using System.Collections.Generic;
using Reflection.Modules.CustomerRelation.ViewModels;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for SalesOrder_DeliverySchedule.xaml
    /// </summary>
    public partial class SalesOrder_DeliverySchedule : WindowElement
    {
        public SalesOrder_DeliverySchedule(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new SEL_T002_VM(ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SalesOrder_DeliverySchedule(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new SEL_T002_VM(ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
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
            if (msg.Notification == "SEL_T002_VM")
            {

                _popup_SoldToParty.IsOpen = false;
                _popup_ReqNo.IsOpen = false;
                _popup_SchBy.IsOpen = false;
                _popup_SchRecBy.IsOpen = false;
                _popup_DelLocation.IsOpen = false;

                popupFltrStatus.IsOpen = false;
                popupFilterParty.IsOpen = false;
                _popupPlant1.IsOpen = false;

            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("SEL_T002_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != _popup_SoldToParty)
            {
                var msg = new NotificationMessage("SEL_T002_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopup.UnselectAll();
                //dgPopupsch_rec_by.UnselectAll();
                //dgPopupSchBy.UnselectAll();
                //dgAddress.UnselectAll();
                //dgReferance.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupsch_rec_by_Unloaded(object sender, RoutedEventArgs e)
        {

        }

        private void dgPopupref_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupref.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
       private void   dgPopupItems_Unloaded(object sender,RoutedEventArgs e)
        {




        }
        private void dgPopupsch_rec_by_Unloaded_1(object sender, RoutedEventArgs e)
        {
            try
            {
               // dgPopupsch_rec_by.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupSchBy_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
               // dgPopupSchBy.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgpono_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void txtSoldToParty_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
    }
}
