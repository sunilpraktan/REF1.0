using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.COM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;

namespace Reflection.Modules.COM.Views
{
    /// <summary>
    /// Interaction logic for MM_M0003.xaml
    /// </summary>
    public partial class COM_M0002 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public COM_M0002(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new COM_M0002_VM(ts_code);
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
