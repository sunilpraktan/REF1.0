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
    public partial class SalesOrderMasterSchedule : WindowElement
    {
        public string ts_code_vm { get; set; }
        public SalesOrderMasterSchedule(string ts_code)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SEL_T002_VM_STD("SD",ts_code);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SalesOrderMasterSchedule(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SEL_T002_VM_STD("SD", ts_code, doc_no);
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
            if (msg.Notification == ts_code_vm)
            {
                _popup_SchBy.IsOpen = false;
                _popup_SchRecBy.IsOpen = false;
                _popup_DelLocation.IsOpen = false;
                popupFltrStatus.IsOpen = false;
                popupFilterParty.IsOpen = false;
                _popupPlant1.IsOpen = false;
                PopSoDetail.IsOpen = false;
                _popup_sch_mode.IsOpen = false;
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(new NotificationMessage(ts_code_vm));
                }));
                e.Handled = true;
            }
        }

        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != _popup_SchBy)
            {
                var msg = new NotificationMessage("SEL_T002_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
