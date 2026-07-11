using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_M0003.xaml
    /// </summary>
    public partial class MM_M0005 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_M0005(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_M0005_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            InitializeComponent();
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "MM_M0005_VM")
            {
                popupAccountCategory.IsOpen = false;
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
