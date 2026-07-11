using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_M0027.xaml
    /// </summary>
    public partial class FICO_M0025 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public FICO_M0025(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new FICO_M0025_VM(ts_code);
            InitializeComponent();
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgLicTypeValue.UnselectAll();
                dgSionValue.UnselectAll();
                //dgCompValue.UnselectAll();
            }
            catch (Exception ex)
            { }
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
