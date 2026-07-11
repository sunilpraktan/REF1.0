using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for ProdcutionPlan.xaml
    /// </summary>
    public partial class ProdcutionPlan : WindowElement
    {
        public ProdcutionPlan()
        {
            InitializeComponent();
            this.DataContext = new PPC_T004_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public ProdcutionPlan(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PPC_T004_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public ProdcutionPlan(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PPC_T004_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "PPC_T004_VM")
            {
                popup_BallSize .IsOpen = false;
                popup_BallType .IsOpen = false;
                popup_Location .IsOpen = false;
                popup_MachineNo .IsOpen = false;
                popup_Plant.IsOpen = false;
                popup_WireSize .IsOpen = false;
                popup_WireType.IsOpen = false;
                popFilterSearch.IsOpen = false;
            }
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgSoDetail.UnselectAll();
                //dgPopupBallSize.UnselectAll();
                //  dgPopupBallType.UnselectAll();
                //dgPopupWireSize.UnselectAll();                
                //  dgPopupLocation.UnselectAll();
                //dgPopupPlant.UnselectAll();
                // dgPopupMachine.UnselectAll();
                e.Handled = true;
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
