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
    /// Interaction logic for WorkCenter.xaml
    /// </summary>
    public partial class WorkCenter : WindowElement
    {
        public WorkCenter(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PPC_M001_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

            tbcTransaction.SelectionChanged += TabControl_SelectionChanged;
            tbcBasicData.SelectionChanged += TabControl_SelectionChanged;
        }
        public WorkCenter(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PPC_M001_VM(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);

            tbcTransaction.SelectionChanged += TabControl_SelectionChanged;
            tbcBasicData.SelectionChanged += TabControl_SelectionChanged;
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "PPC_M001_VM")
            {
                popup_Location.IsOpen = false;
                popup_WCTypeCode.IsOpen = false;
                popup_WCSubTypeCode.IsOpen = false;
                popup_WCCategory.IsOpen = false;
                popup_Place.IsOpen = false;
                popup_ControlKey.IsOpen = false;
                popup_Group.IsOpen = false;
                popup_Make.IsOpen = false;
                popup_Employee.IsOpen = false;
                popup_Party.IsOpen = false;
                popup_Unit.IsOpen = false;
                popup_Capacity.IsOpen = false;                
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
                var msg = new NotificationMessage("PPC_M001_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
