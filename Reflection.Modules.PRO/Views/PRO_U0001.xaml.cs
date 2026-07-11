using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.PRO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Reflection.Modules.PRO.Views
{
    /// <summary>
    /// Interaction logic for PRO_T001.xaml
    /// </summary>
    public partial class PRO_U0001 : WindowElement
    {
        public PRO_U0001(string request)
        {
            InitializeComponent();
            //this.DataContext = new PRO_U0001_VM("RQ", ts_code);
            //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));

        }
        public PRO_U0001(string request, object para_obj)
        {
            InitializeComponent();
            this.DataContext = new PRO_U0001_VM("RQ", para_obj);
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
