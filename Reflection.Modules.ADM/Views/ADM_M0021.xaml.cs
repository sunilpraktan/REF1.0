using Reflection.Modules.ADM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.ADM.Views
{
    /// <summary>
    /// Interaction logic for ADM_M0017.xaml
    /// </summary>
    public partial class ADM_M0021 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public ADM_M0021(string ts_code)
        {
            ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new ADM_M0021_VM(ts_code);

        }
        public ADM_M0021(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M0021_VM(ts_code);
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
