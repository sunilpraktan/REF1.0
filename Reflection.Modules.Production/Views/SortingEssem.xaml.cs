using System.Windows;
using System.Windows.Controls;
using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for SortingEssem.xaml
    /// </summary>
    public partial class SortingEssem : WindowElement
    {
        public SortingEssem(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ESO_T001_VM_2(ts_code);
        }
        public SortingEssem(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ESO_T001_VM_2(ts_code,doc_no);
        }
        private void dgPopupItems_Unloaded(object sender, RoutedEventArgs e)
        {            
            dgData.UnselectAll();
            dgMachine.UnselectAll();            
            dgUOM.UnselectAll();

            e.Handled = true;
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
