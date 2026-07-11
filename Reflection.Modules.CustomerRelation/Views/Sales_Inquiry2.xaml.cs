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
    /// Interaction logic for Sales_Inquiry2.xaml
    /// </summary>
    public partial class Sales_Inquiry2 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public Sales_Inquiry2(string ts_code)
        {
            InitializeComponent();
            this.ts_code_vm = ts_code;
            this.DataContext = new SEL_T001_INQ_VM("SN",ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public Sales_Inquiry2(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new SEL_T001_INQ_VM("SN",ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                popFilterSearch.IsOpen = false;
                popup_Party.IsOpen = false;
                popupLocation.IsOpen = false;
                popupCountry.IsOpen = false;
                popupState.IsOpen = false;
                popupSeller.IsOpen = false;
                popupCurrency.IsOpen = false;
                popup_status.IsOpen = false;
                popupBuyer.IsOpen = false;
                popupRefParty.IsOpen = false;
                popupRefContPerson.IsOpen = false;
                popupSalesOrg.IsOpen = false;
                popupSalesGroup.IsOpen = false;
            }
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
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("SEL_T001_INQ_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popupCurrency)
            {
                var msg = new NotificationMessage("SEL_T001_INQ_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
