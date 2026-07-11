using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Controls;
using Reflection.Presentation.ViewModel;
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

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for Material_Conversion.xaml
    /// </summary>
    public partial class Material_Conversion : WindowElement
    {
        public Material_Conversion(string ts_code)
        {
            InitializeComponent();
           this.DataContext = new MM_T001_MC_VM(ts_code);
        }
        public Material_Conversion(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_MC_VM(ts_code,doc_no);
        }

        private void DgPopUpUnloaded(object sender,RoutedEventArgs e)
        {
            try
            {
                //dggrd.UnselectAll();
                dgmov_tp.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dggrd_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dggrd.UnselectAll();
                
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgmov_tp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgmov_tp.UnselectAll();
            }
            catch (Exception ex)
            {}
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
