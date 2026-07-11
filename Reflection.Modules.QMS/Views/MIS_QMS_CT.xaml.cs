using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.QMS.ViewModels;
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

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for MIS_QMS_CT.xaml
    /// </summary>
    public partial class MIS_QMS_CT : WindowElement
    {
        public MIS_QMS_CT()
        {
            InitializeComponent();
            this.DataContext = new MIS_QMS_CT_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public MIS_QMS_CT(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_QMS_CT_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public MIS_QMS_CT(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MIS_QMS_CT_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "MIS_QMS_CT_VM")
            {
                popup_inst.IsOpen = false;
                popup_party.IsOpen = false;
                popup_Test.IsOpen = false;
                popup_lab.IsOpen = false;
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
