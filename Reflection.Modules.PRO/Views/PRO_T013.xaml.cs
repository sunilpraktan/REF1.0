using System.Windows.Controls;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.PRO.ViewModels;

namespace Reflection.Modules.PRO.Views
{
    /// <summary>
    /// Interaction logic for PRO_T001.xaml
    /// </summary>
    public partial class PRO_T013 : WindowElement
    {
        public PRO_T013(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PRO_T005_VM("IN", ts_code);
        }
        public PRO_T013(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PRO_T005_VM("IN", ts_code, doc_no);
        }
        private bool isManualEditCommit;
        //This will update the bound object whenever a cell edit is ending, i.e.whenever the cell looses focus.
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
