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
using Reflection.Presentation.Windows.Controls;
using Reflection.Module.Project.ViewModels;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Module.Project.Views
{
    /// <summary>
    /// Interaction logic for Issues.xaml
    /// </summary>
    public partial class Issues : WindowElement
    {
        public Issues(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PRO_T003_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public Issues(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PRO_T003_VM(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "PRO_T003_VM")
            {
                popup_assginto.IsOpen = false;
                popup_phase.IsOpen = false;
                popup_project.IsOpen = false;
                popup_Task.IsOpen = false;
                popup_reporterName.IsOpen = false;
               
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
