using System.Windows.Controls;
using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_T001.xaml
    /// </summary>
    public partial class MM_T007 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public MM_T007(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_T007_VM("CP", ts_code);
            InitializeComponent();
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
