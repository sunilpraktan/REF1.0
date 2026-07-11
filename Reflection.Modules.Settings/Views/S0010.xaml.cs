using Reflection.Modules.Settings.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.Settings.Views
{
    /// <summary>
    /// Interaction logic for S0001.xaml
    /// </summary>
    public partial class S0010 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public S0010(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new SYS_S0010_VM(ts_code);
            InitializeComponent();
        }

        private bool isManualEditCommit;

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
