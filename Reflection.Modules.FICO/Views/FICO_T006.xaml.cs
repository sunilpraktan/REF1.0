using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_T001.xaml
    /// </summary>
    public partial class FICO_T006 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public FICO_T006(string ts_code)
        {
            this.ts_code_vm = ts_code;
            
            this.DataContext = new FICO_T006_VM("PR", ts_code);
            InitializeComponent();
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDocDetails.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived2);
        }
        public FICO_T006(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new FICO_T006_VM("PR", ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDocDetails.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived2);
        }
        public FICO_T006(string ts_code, STD_LIST_BE STD_LIST_OBJ)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new FICO_T006_VM(ts_code,STD_LIST_OBJ);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

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
                popStatus.IsOpen = false;
                popup_DocType.IsOpen = false;
                _popupCurrency.IsOpen = false;
                _popup_Party.IsOpen = false;
                _popupCurrency.IsOpen = false;
                popupGL.IsOpen = false;
                popup_PayMethod.IsOpen = false;
                popup_ProfitCenter.IsOpen = false;
                popupFltrStatus.IsOpen = false;
                _popupSeller1.IsOpen = false;
                popupFilterParty.IsOpen = false;
                _popupLocationFilter.IsOpen = false;
                popup_SPGLCode.IsOpen = false;
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

        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popFilterSearch)
            {
                var msg = new NotificationMessage(ts_code_vm);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void NotificationMessageReceived2(NotificationMessage msg)
        {
            if (msg.Notification == "Enable/Disable Special GL Code")
            {
                bool Temp = (bool)msg.Sender;
                if (Temp == false)
                {
                    txtSPGL_Code.IsReadOnly = true;
                    txtSPGL_Code.IsEnabled = false;
                }
                else if (Temp == true)
                {
                    txtSPGL_Code.IsReadOnly = false;
                    txtSPGL_Code.IsEnabled = true;
                }
            }
        }
    }
}
