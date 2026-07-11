using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for Goods_Receipt_STD.xaml
    /// </summary>
    public partial class Goods_Movement_STD : WindowElement
    {
        private bool isManualEditCommit;
        public Goods_Movement_STD(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_STD_GM_VM(ts_code);
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
