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
    /// Interaction logic for Wastage_Entry.xaml
    /// </summary>
    public partial class Wastage_Entry : WindowElement
    {
        public Wastage_Entry(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new SEL_T099_VM(ts_code);
        }
        public Wastage_Entry(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new SEL_T099_VM(ts_code, doc_no);
        }
        private void DgPopUp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgWastageData.UnselectAll();
                //dgcustomer.UnselectAll();
                
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
