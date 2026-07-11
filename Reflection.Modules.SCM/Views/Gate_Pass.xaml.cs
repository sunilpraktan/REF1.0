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
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.SCM.ViewModels;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for Gate_Pass.xaml
    /// </summary>
    public partial class Gate_Pass : WindowElement
    {
        public Gate_Pass(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_T004_GP_VM(ts_code);
        }
        public Gate_Pass(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T004_GP_VM(ts_code,doc_no);
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgitem.UnselectAll();
                dgPopupEmp.UnselectAll();                   
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
    }
}
