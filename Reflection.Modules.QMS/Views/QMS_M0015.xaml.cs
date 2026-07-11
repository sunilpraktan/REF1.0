using System;
using System.Windows.Controls;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.QMS;
using System.Windows.Input;


namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for QMS_M0015.xaml
    /// </summary>
    public partial class QMS_M0015 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public QMS_M0015(string ts_code)
        {
            ts_code_vm = ts_code; //transaction screen code
            this.DataContext = new QMS_M0001_VM(ts_code);
            InitializeComponent();
        }

        private bool isManualEditCommit;
        private void HandleMainDataGridCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)//later explain
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
