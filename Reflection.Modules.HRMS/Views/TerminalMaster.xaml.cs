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
using Reflection.Modules.Finance.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.HRMS.ViewModels;

namespace Reflection.Modules.HRMS.Views
{
    /// <summary>
    /// Interaction logic for TerminalMaster.xaml
    /// </summary>
    public partial class TerminalMaster : WindowElement
    {
        public TerminalMaster()
        {
            InitializeComponent();
            this.DataContext = new HRM_M015_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster.SelectionChanged += TabControl_SelectionChanged;
        }
        public TerminalMaster(string doc_no)
        {
            InitializeComponent();
            this.DataContext = new HRM_M015_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster.SelectionChanged += TabControl_SelectionChanged;
        }
        public TerminalMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new HRM_M015_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster.SelectionChanged += TabControl_SelectionChanged;
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
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "HRM_M015_VM")
            {
                _popupStstus.IsOpen = false;
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("HRM_M015_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
