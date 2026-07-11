using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_M0003.xaml
    /// </summary>
    public partial class MM_M0010 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_M0010(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_M0010_VM(ts_code);
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            InitializeComponent();
        }
        //private void NotificationMessageReceived(NotificationMessage msg)
        //{
        //    if (msg.Notification == "MM_M0010_VM")
        //    {
        //        popup_ItemCode.IsOpen = false;
        //        popup_CountryCode.IsOpen = false;
        //    }
        //}

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
