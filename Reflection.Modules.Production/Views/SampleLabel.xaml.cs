using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for SampleLabel.xaml
    /// </summary>
    public partial class SampleLabel : WindowElement
    {
        private bool isManualEditCommit;
        public SampleLabel(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T005_AVM(ts_code);
        }
        public SampleLabel(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T005_AVM(ts_code,doc_no);
        }

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
