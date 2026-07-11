using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_T001.xaml
    /// </summary>
    public partial class FICO_T008 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public FICO_T008(string ts_code)
        {
            this.ts_code_vm = ts_code;
            this.DataContext = new FICO_T008_VM("AR", ts_code);
            InitializeComponent();
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDocDetails.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived2);
        }
        public FICO_T008(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new FICO_T008_VM("AR", ts_code, doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDocDetails.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived2);
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
                popupFltrStatus.IsOpen = false;
                _popupSeller1.IsOpen = false;
                popupFilterParty.IsOpen = false;
                _popupLocationFilter.IsOpen = false;
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
        private void NotificationMessageReceived2(NotificationMessage msg)
        {
            if (msg.Notification == "Enable/Disable Special GL Code")
            {

            }
        }
    }
}
