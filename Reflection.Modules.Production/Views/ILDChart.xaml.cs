using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using Reflection.WebServices.Gateway;
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

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for ILDChart.xaml
    /// </summary>
    public partial class ILDChart : WindowElement
    {
        public ILDChart(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T001_VM(ts_code);
        }
        public ILDChart(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T001_VM(ts_code,doc_no);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupPlant.UnselectAll();
                //dgPopupMachine.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgParameters_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {
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
