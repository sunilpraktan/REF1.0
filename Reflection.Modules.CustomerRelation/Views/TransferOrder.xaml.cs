using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;


namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for TransferOrder.xaml
    /// </summary>
    public partial class TransferOrder : WindowElement
    {
        public TransferOrder(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new SEL_T004_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public TransferOrder(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new SEL_T004_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public TransferOrder(string doc_no,string ts_code,string ts_name_display)
        {
            AppSessionState.ViewTitle = ts_name_display;
            InitializeComponent();
            this.DataContext = new SEL_T004_VM(doc_no, ts_code, ts_name_display);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "SEL_T004_VM")
            {
                _popupTransporter.IsOpen = false;
                _popup_status.IsOpen = false;
                _popuplocation_Id.IsOpen = false;
                _popupShippingMode.IsOpen = false;
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
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {

        }
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnRefSO_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
