using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.ADM.ViewModels;
using System.Windows.Controls;

namespace Reflection.Modules.ADM.Views
{
    /// <summary>
    /// Interaction logic for ADM_T0001.xaml
    /// </summary>
    public partial class ADM_T001 : WindowElement
    {
        public ADM_T001(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_T001_VM(ts_code);
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
