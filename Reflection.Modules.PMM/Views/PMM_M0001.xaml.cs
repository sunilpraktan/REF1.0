using Reflection.Modules.PMM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.PMM.Views
{
    /// <summary>
    /// Interaction logic for PMM_M0001.xaml
    /// </summary>
    public partial class PMM_M0001 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PMM_M0001(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new PMM_M0001_VM(ts_code,"03");
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

        private void txtCategory_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtCategory.Text == "V")
            {
                tbFleet.Visibility = Visibility.Visible;
                tbFleetTech.Visibility = Visibility.Visible;
            }
            //else if (txtCategory.Text == "S" || txtCategory.Text == "E") // NOTE: add logic if required.
            //{
            //    tbInstrument.Visibility = Visibility.Collapsed;
            //    tbFleetTech.Visibility = Visibility.Collapsed;
            //}
            else
            {
                tbFleet.Visibility = Visibility.Collapsed;
                tbFleetTech.Visibility = Visibility.Collapsed;
            }
        }
    }
}
