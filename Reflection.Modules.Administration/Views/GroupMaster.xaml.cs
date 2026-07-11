using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Interaction logic for GroupMaster.xaml
    /// </summary>
    public partial class GroupMaster : WindowElement
    {
        public GroupMaster()
        {
            InitializeComponent();
            this.DataContext = new ADM_M058_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

            //tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }
        public GroupMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_M058_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

            //tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }
        public GroupMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M058_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

            //tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            //tbcDetail.SelectionChanged += TabControl_SelectionChanged;
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ADM_M058_VM")
            {
                //popup_PartyType.IsOpen = false;
                //popup_PartyGroup.IsOpen = false;
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
                var msg = new NotificationMessage("ADM_M058_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
