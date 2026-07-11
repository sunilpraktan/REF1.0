using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for Store_Location.xaml
    /// </summary>
    public partial class Store_Location : WindowElement
    {
        public Store_Location(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_M001_VM(ts_code);
        }
        public Store_Location(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_M001_VM(ts_code,doc_no);
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
