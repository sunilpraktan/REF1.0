using Reflection.Modules.HRMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;

namespace Reflection.Modules.HRMS.Views
{
    /// <summary>
    /// Interaction logic for HRM_M0005.xaml
    /// </summary>
    public partial class HRM_M0002 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public HRM_M0002(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new HRM_M0002_VM(ts_code);
            InitializeComponent();
        }
        private bool isManualEditCommit;
        private void HandleMainDataGridCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)//later explain
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
