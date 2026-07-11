using System;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for ServiceRequestForm.xaml
    /// </summary>
    public partial class ServiceRequestForm : WindowElement
    {
        //bool isTravelled = false;
        public ServiceRequestForm(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new QMS_T002_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public ServiceRequestForm(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new QMS_T002_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "QMS_T002_VM")
            {
                popup_party.IsOpen = false;
                popup_sono.IsOpen = false;
                popup_refdoc.IsOpen = false;
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
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != popup_lab)
            {
                var msg = new NotificationMessage("QMS_T002_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
