using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_M0003.xaml
    /// </summary>
    public partial class MM_M0007 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_M0007(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_M0007_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            InitializeComponent();
        }
        public MM_M0007(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_M0007_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgParty.UnselectAll();
                dgCategory.UnselectAll();
                dgSubCategory.UnselectAll();
                dgItemType.UnselectAll();
                dgSubItemType.UnselectAll();
                dgUOM.UnselectAll();
                dgProduct.UnselectAll();
                dgAsset.UnselectAll();
                dgWgtUOM.UnselectAll();
                dgVolume.UnselectAll();
                dgMaterial.UnselectAll();
                dgPurUOM.UnselectAll();
                dgRGGroup.UnselectAll();
                dgCommodity.UnselectAll();
                dgSupTax.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "MM_M0007_VM")
            {
                popup_AccountingGroup.IsOpen = false;
                popup_ValueClass.IsOpen = false;
                popup_ReconAcc.IsOpen = false;
                popup_TaxIndicator.IsOpen = false;
                popupiuom.IsOpen = false;
                popupsuom.IsOpen = false;
                popupbuom.IsOpen = false;
                popupstkuom.IsOpen = false;
                popupkey.IsOpen = false;
                popupqmsys.IsOpen = false;
                popupcerti.IsOpen = false;
                ppExportGroup.IsOpen = false;
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

    }
}
