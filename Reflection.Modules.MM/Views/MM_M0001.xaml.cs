using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_M0001.xaml
    /// </summary>
    public partial class MM_M0001 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_M0001(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_M0001_VM(ts_code);
            InitializeComponent();
        }
        public MM_M0001(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_M0001_VM(ts_code, doc_no);
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
