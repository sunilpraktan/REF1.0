using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.HRMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;

namespace Reflection.Modules.HRMS.Views
{
    /// <summary>
    /// Interaction logic for HRM_T001.xaml
    /// </summary>
    public partial class HRM_T001 : WindowElement
    {
        public HRM_T001()
        {
            InitializeComponent();
            this.DataContext = new HRM_T001_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster.SelectionChanged += TabControl_SelectionChanged;
        }
        public HRM_T001(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new HRM_T001_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster.SelectionChanged += TabControl_SelectionChanged;
        }
        public HRM_T001(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new HRM_T001_VM();
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
            if (msg.Notification == "HRM_T001_VM")
            {
                _popupRequestCode.IsOpen = false;
                _popupSubRequestCode.IsOpen = false;
                _popupObjectType.IsOpen = false;
                _popupReasonCode.IsOpen = false;
                _popupSubReasonCode.IsOpen = false;
                _popupDocCategory.IsOpen = false;
                _popupDocumentType.IsOpen = false;
                _popupStatus.IsOpen = false;
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("HRM_T001_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

    }
}
