using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Windows.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Apps.Store.Scheduler
{
    /// <summary>
    /// Interaction logic for JobScheduler.xaml
    /// </summary>
   
    public partial class JobScheduler : WindowElement
    {
        public JobScheduler()
        {
            InitializeComponent();
            this.DataContext = new COM_T004_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "COM_T004_VM")
            {
                //popup_Customer.IsOpen = false;
                //popup_FormType.IsOpen = false;
                //popup_Quarter.IsOpen = false;
                //popup_FinYear.IsOpen = false;

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
