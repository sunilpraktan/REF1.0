using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Description for RTQFR.
    /// </summary>
    public partial class RTQFR : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the RTQFR class.
        /// </summary>
        public RTQFR(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T002_A_RTQFR_VM(ts_code);
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived)
        }
        public RTQFR(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T002_A_RTQFR_VM(ts_code, doc_no);
        }
       

        private void dgPopUpQFRNo_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpQFRNo.UnselectAll();

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
        private void dgPopUpcmplnt_HandlBy_Unloaded(object sender,RoutedEventArgs e)
        {
         
        }
    }
}