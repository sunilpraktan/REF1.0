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
    /// Interaction logic for Goods_Reciept_Note_Service.xaml
    /// </summary>
    public partial class Goods_Reciept_Note_Service : WindowElement
    {
        public Goods_Reciept_Note_Service(string ts_code)
        {    
            InitializeComponent();
            this.DataContext = new MM_T001_GRN_Service_VM(ts_code);
        }
        public Goods_Reciept_Note_Service(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_GRN_Service_VM(ts_code,doc_no);
        }
        private void dgmovtype_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgmovtype.UnselectAll();
                dgrefdoctype.UnselectAll();
                dgrefdocno.UnselectAll();
                dgsupplier.UnselectAll();
                dgtransporter.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
    }
}
