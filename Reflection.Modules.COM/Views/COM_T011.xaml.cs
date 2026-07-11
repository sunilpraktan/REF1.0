using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.COM.ViewModels;
using System.Windows.Controls;

namespace Reflection.Modules.COM.Views
{
    /// <summary>
    /// Interaction logic for COM_T011.xaml
    /// </summary>
    public partial class COM_T011 : WindowElement
    {
        public COM_T011()
        {
            InitializeComponent();
            //this.DataContext = new COM_T011_VM(ts_code);
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
