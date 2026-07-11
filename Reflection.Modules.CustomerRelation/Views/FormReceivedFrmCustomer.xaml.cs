using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for InstrumentMaster.xaml
    /// </summary>
    public partial class FormReceivedFrmCustomer : WindowElement
    {
        public FormReceivedFrmCustomer()
        {
            InitializeComponent();
            this.DataContext = new ESEL_T001_AVM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }
        public FormReceivedFrmCustomer(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ESEL_T001_AVM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }
        public FormReceivedFrmCustomer(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ESEL_T001_AVM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ESEL_T001_AVM")
            {
                popup_Customer.IsOpen = false;
                popup_FormType.IsOpen = false;
                popup_Quarter.IsOpen = false;
                popup_FinYear.IsOpen = false;
                popup_Customer1.IsOpen = false;
                popup_FormType1.IsOpen = false;
                popup_Quarter1.IsOpen = false;
                popup_FinYear1.IsOpen = false;
                popup_Customer1.IsOpen = false;
                popup_FormType1.IsOpen = false;
                popup_FinYear1.IsOpen = false;
                popup_Quarter1.IsOpen = false;
            }
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

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("ESEL_T001_AVM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
