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
    public partial class FICO_T001 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public FICO_T001(string ts_code)
        {
            
            ts_code_vm = ts_code;
            this.DataContext = new FICO_T001_VM(ts_code,"AD");
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            
        }
        public FICO_T001(string ts_code, string doc_no)
        {
            
            ts_code_vm = ts_code;
            this.DataContext = new FICO_T001_VM(ts_code, "AD", doc_no);
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                _popupCompany.IsOpen = false;
                _popupCurrency.IsOpen = false;
                _popupDocType.IsOpen = false;
                _popupPayMethod.IsOpen = false;
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
                var msg = new NotificationMessage("FICO_T001_VM");
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
                var msg = new NotificationMessage("FICO_T001_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
