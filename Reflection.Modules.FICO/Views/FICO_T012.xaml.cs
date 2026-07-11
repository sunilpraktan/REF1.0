using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_T001.xaml
    /// </summary>
    public partial class FICO_T012 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public FICO_T012(string ts_code)
        {
            
            ts_code_vm = ts_code;
            this.DataContext = new FICO_T012_VM(ts_code, "CB");
            InitializeComponent();
        }
        public FICO_T012(string ts_code, string doc_no)
        {
            
            ts_code_vm = ts_code;
            this.DataContext = new FICO_T012_VM(ts_code, "CB");
            InitializeComponent();
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
