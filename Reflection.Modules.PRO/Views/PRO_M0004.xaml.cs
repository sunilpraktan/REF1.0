using Reflection.Modules.PRO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.PRO.Views
{
    /// <summary>
    /// Interaction logic for PRO_M0001.xaml
    /// </summary>
    public partial class PRO_M0004 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PRO_M0004(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new PRO_M0004_VM(ts_code);
            InitializeComponent();
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
