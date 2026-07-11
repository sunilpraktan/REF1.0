using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.SCM.ViewModels;
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

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for Inward_Outward.xaml
    /// </summary>
    public partial class Inward_Outward : WindowElement
    {
        public Inward_Outward(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_T004_IO_VM(ts_code);
        }
        public Inward_Outward(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T004_IO_VM(ts_code,doc_no);
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            dgPopupEmp.UnselectAll();
            dgitem.UnselectAll();
            dgPopupunit.UnselectAll();
            dgtransagency.UnselectAll();
            dgvendor.UnselectAll();
            dgRequester.UnselectAll();
        }
        
    }
}