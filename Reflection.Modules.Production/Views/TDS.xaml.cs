using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for TDS.xaml
    /// </summary>
    public partial class TDS : WindowElement
    {
        public TDS(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ENG_T004_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public TDS(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ENG_T004_VM(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ENG_T004_VM")
            {
                popup_Location.IsOpen = false;
                popup_BallDia.IsOpen = false;
                popup_ModelNo.IsOpen = false;
                //popup_FGilterInk.IsOpen = false;
                //popup_FGilterILD.IsOpen = false;
            }
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgProduct.UnselectAll();
                dgmodel.UnselectAll();
                dgInk.UnselectAll();
                dgIld.UnselectAll();
                dgmachine.UnselectAll();
                dgplant.UnselectAll();
                //dgBallMk.UnselectAll();
                //dgWireMake.UnselectAll();
                dgWireType.UnselectAll();
                dgPopupTooldata.UnselectAll();
                dgToolItem.UnselectAll();
                dgPopupDrilldata.UnselectAll();
                dgDrilllItem.UnselectAll();
                dgPopupSparedata.UnselectAll();
                dgSpareItem.UnselectAll();

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
        
    }
}
