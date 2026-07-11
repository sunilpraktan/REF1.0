using Reflection.Modules.SCM.ViewModels;
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
    /// Interaction logic for Current_Stock1.xaml
    /// </summary>
    public partial class Current_Stock1 : WindowElement
    {
        public Current_Stock1(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new CurrentStockFG(ts_code);
        }
        public Current_Stock1(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new CurrentStockFG(ts_code,doc_no);
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupplant.UnselectAll();
                //dgItemValue.UnselectAll();
                ////dgCategory.UnselectAll();         
                //dgUOM.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
    }
}
