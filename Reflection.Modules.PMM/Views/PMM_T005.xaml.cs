using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.PMM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;

namespace Reflection.Modules.PMM.Views
{
    /// <summary>
    /// Interaction logic for MM_M0003.xaml
    /// </summary>
    public partial class PMM_T005 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PMM_T005(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PMM_T005_VM(ts_code,"07");
            
        }
        public PMM_T005(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PMM_T005_VM(ts_code, "07", doc_no);
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
