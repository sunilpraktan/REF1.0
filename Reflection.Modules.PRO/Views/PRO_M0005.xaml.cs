using Reflection.Modules.PRO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace Reflection.Modules.PRO.Views
{
    /// <summary>
    /// Interaction logic for PRO_M0001.xaml
    /// </summary>
    public partial class PRO_M0005 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PRO_M0005(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new PRO_M0005_VM(ts_code,"102");
            InitializeComponent();
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                popup_AccountingGroup.IsOpen = false;

            }
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgaddress.UnselectAll();
                dgcontpers.UnselectAll();
                dggroup.UnselectAll();
                dgPartyType.UnselectAll();
                dgCurrency.UnselectAll();
                dgemployee.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;

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
                var msg = new NotificationMessage(ts_code_vm);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

    }
}
