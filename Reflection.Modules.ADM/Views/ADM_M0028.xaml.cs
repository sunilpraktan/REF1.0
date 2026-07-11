using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Reflection.Modules.ADM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace Reflection.Modules.ADM.Views
{
    /// <summary>
    /// Interaction logic for ADM_M00018.xaml
    /// </summary>
    public partial class ADM_M0028 :WindowElement
    {
        public string ts_code_vm { get; set; }
        public ADM_M0028(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new ADM_M0028_VM (ts_code);
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
