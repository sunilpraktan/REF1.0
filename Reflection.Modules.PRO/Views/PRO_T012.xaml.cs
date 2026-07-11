using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.PRO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.PRO.Views
{
    /// <summary>
    /// Interaction logic for PRO_T001.xaml
    /// </summary>
    public partial class PRO_T012 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PRO_T012(string ts_code)
        {
            ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new PRO_T001_VM("RQ", ts_code);
            
        }
        public PRO_T012(string ts_code, string doc_no)
        {
            ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new PRO_T001_VM("RQ", ts_code, doc_no);
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
