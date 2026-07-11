using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.COM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;

namespace Reflection.Modules.COM.Views
{
    public partial class COM_T001 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public COM_T001(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new COM_T001_VM(ts_code, "NT");

        }
        public COM_T001(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new COM_T001_VM(ts_code, "NT", doc_no);
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
