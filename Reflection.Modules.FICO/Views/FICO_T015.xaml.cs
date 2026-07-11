using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_T001.xaml
    /// </summary>
    public partial class FICO_T015 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public FICO_T015(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new FICO_T015_VM(ts_code);
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "FICO_T015_VM")
            {
                popup_FinYear.IsOpen = false;
                popup_PostPrd.IsOpen = false;
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
