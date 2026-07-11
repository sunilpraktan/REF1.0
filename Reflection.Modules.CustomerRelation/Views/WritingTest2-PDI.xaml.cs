using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.CustomerRelation.ViewModels;
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

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for WritingTest2_PDI.xaml
    /// </summary>
    public partial class WritingTest2_PDI : WindowElement
    {
        public WritingTest2_PDI(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T003_A_VM2(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public WritingTest2_PDI(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T003_A_VM2(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ECRM_T003_A_VM2")
            {
                unitpopup.IsOpen = false;
                machinepopup.IsOpen = false;
                customerpopup.IsOpen = false;
                sonopopup.IsOpen = false;
                samplepopup.IsOpen = false;
                Operatorpopup.IsOpen = false;
                shiftpopup.IsOpen = false;
                testtypepopup.IsOpen = false;
                wtmachinepopup.IsOpen = false;
                Itempopup.IsOpen = false;
                inkpopup.IsOpen = false;
                ballmakepopup.IsOpen = false;
                ballsizepopup.IsOpen = false;
                wirepopup.IsOpen = false;
                wiresizepopup.IsOpen = false;
                tiptypepopup.IsOpen = false;
                doctppopup.IsOpen = false;

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

        private void Dgbarcode_Unloaded(object sender, RoutedEventArgs e)
        {
            dgrefdoctype.UnselectAll();
            Dgbarcode.UnselectAll();

            e.Handled = true;
        }
        
    }
}
