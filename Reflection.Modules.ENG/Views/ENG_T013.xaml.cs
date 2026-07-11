using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.ENG.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;

namespace Reflection.Modules.ENG.Views
{
    /// <summary>
    /// Interaction logic for ENG_T013.xaml
    /// </summary>
    public partial class ENG_T013 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public ENG_T013(string ts_code, STD_LIST_BE STD_OBJ)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new ENG_T013_VM(ts_code, STD_OBJ);
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
