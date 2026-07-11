using Reflection.BusinessEntity.ENG;
using Reflection.Modules.MM.ViewModels;
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
    public partial class S0021 : WindowElement
    {
        public S0021(ENG_T005_B char_object)
        {
            this.DataContext = new SYS_S0021_VM(char_object);
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
