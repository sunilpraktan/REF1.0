using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Windows.Controls;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : WindowElement
    {
        public Test()
        {
            InitializeComponent();
            //this.DataContext = new ENG_T004_VM();
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            //try
            //{
               

            //}
            //catch (Exception ex)
            //{ }
            e.Handled = true;
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
