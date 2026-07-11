using System;
using System.Windows;
using System.Windows.Controls;
using Reflection.BusinessEntity;
using Reflection.Modules.PRO.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.PRO.Views
{
    /// <summary>
    /// Interaction logic for PRO_T001.xaml
    /// </summary>
    public partial class PRO_T010 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PRO_T010(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PRO_T005_VM("RN", ts_code);
        }
        public PRO_T010(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PRO_T005_VM("RN", ts_code);
        }
        public PRO_T010(string ts_code, STD_LIST_BE REF_OBJECT)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PRO_T005_VM(ts_code, REF_OBJECT);
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
