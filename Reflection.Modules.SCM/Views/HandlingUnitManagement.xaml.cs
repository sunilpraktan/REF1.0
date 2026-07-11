using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for HandlingUnitManagement.xaml
    /// </summary>
    public partial class HandlingUnitManagement : WindowElement
    {
        private bool isManualEditCommit;
        public HandlingUnitManagement(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T003_STD_VM("CP", ts_code);
        }
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
