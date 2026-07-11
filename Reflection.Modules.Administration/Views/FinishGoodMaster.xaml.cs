using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Windows.Controls;
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

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Interaction logic for FinishGoodMaster.xaml
    /// </summary>
    public partial class FinishGoodMaster : WindowElement
    {
        public FinishGoodMaster()
        {
            InitializeComponent();
            this.DataContext = new ZADM_M010_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public FinishGoodMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ZADM_M010_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public FinishGoodMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ZADM_M010_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgmodel.UnselectAll();
                dgWireType.UnselectAll();
                dgWireSize.UnselectAll();
                dgBallDia.UnselectAll();
                dgBallType.UnselectAll();
                dgTipLength.UnselectAll();
                dgInk.UnselectAll();
                dgIld.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ZADM_M010_VM")
            {
                popup_UnitCode.IsOpen = false;                
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
