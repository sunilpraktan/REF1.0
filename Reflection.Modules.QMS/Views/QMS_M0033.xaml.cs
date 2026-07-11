using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for ParameterProfile_SelectedSet_.xaml
    /// </summary>
    public partial class QMS_M0033 : WindowElement
    {
        public QMS_M0033(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new QMS_M0033_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public QMS_M0033(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new QMS_M0033_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
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
            if (msg.Notification == "QMS_M0033_VM")
            {
                

            }

        }

        private void btnStyle_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
