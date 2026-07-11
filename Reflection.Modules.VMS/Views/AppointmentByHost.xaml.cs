using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.VMS.ViewModels;
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

namespace Reflection.Modules.VMS.Views
{
    /// <summary>
    /// Interaction logic for AppointmentByHost.xaml
    /// </summary>
    public partial class AppointmentByHost : WindowElement
    {
        public AppointmentByHost(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new VMS_T001_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            //tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }
        public AppointmentByHost(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new VMS_T001_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            //tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "VMS_T001_VM")
            {
                popup_Salutation.IsOpen = false;
                popup_VCategory.IsOpen = false;
                popup_VPurpose.IsOpen = false;
                popup_MeetingPlace.IsOpen = false;
                popup_VCompany.IsOpen = false;
                popup_VNation.IsOpen = false;
                popup_VCountry.IsOpen = false;
                popup_VState.IsOpen = false;                
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
                var msg = new NotificationMessage("VMS_T001_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
