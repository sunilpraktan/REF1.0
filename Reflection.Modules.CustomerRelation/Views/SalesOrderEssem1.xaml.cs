using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Windows.Controls;
using Reflection.WebServices.Gateway;
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
    /// Description for SalesOrderMaster.
    /// </summary>
    public partial class SalesOrderEssem1 : WindowElement
    {
        public string ts_code_vm { get; set; }
        /// <summary>
        /// Initializes a new instance of the SalesOrderMaster class.
        /// </summary>
        public SalesOrderEssem1(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new SalesOrderEssemVM1("SO",ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SalesOrderEssem1(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new SalesOrderEssemVM1("SO",ts_code, doc_no);
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
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
               
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                //popup_Ref_doc_no.IsOpen = false;
                popup_SOtype.IsOpen = false;
                popup_NotifyParty.IsOpen = false;
                popTradeIndicator.IsOpen = false;
                popup_NotifyParty2.IsOpen = false;
                /*opup_SOtype1.IsOpen = false;*/
                popup_Buyer.IsOpen = false;
                _popupSeller.IsOpen = false;
                _popupTransporter.IsOpen = false;
                _popupBillAdddress.IsOpen = false;
                _popupDeliveryAdddress.IsOpen = false;
                _popupSeller.IsOpen = false;
                _popupCurrency.IsOpen = false;
                _popupIncoterm.IsOpen = false;
                _popupPayTerms.IsOpen = false;
                _popupRefParty.IsOpen = false;
                _popupOurBank.IsOpen = false;
                _popupNastroBank.IsOpen = false;
                _popupSalesOrg.IsOpen = false;
                _popupSalesGroup.IsOpen = false;
                _popupPlant1.IsOpen = false;
                _popup_SoldToParty.IsOpen = false;
                _popup_ShipToParty.IsOpen = false;
                popup_BussPlace.IsOpen = false;
                _popup_status.IsOpen = false;
                popupDocType.IsOpen = false;
                popupFltrStatus.IsOpen = false;
                popupFilterParty.IsOpen = false;
                _popupPlant2.IsOpen = false;
                _popuptr_mode.IsOpen = false;
                popFilterSearch.IsOpen = false;
                _popupComp.IsOpen = false;
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("SalesOrderEssemVM1");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != _popupCurrency)
            {
                var msg = new NotificationMessage("SalesOrderEssemVM1");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}


