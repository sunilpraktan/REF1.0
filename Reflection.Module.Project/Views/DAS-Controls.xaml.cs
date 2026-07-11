using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.Project.ViewModels;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Module.Project.Views
{
    /// <summary>
    /// Interaction logic for DAS_Controls.xaml
    /// </summary>
    public partial class DAS_Controls : WindowElement
    {
        public DAS_Controls()
        {
            InitializeComponent();
            this.DataContext = new RND_T010_A_VM();

            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "RND_T010_A_VM")
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

        private void dgAdminData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
