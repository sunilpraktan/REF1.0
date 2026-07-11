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
    /// Interaction logic for MIS_SCM_Indent.xaml
    /// </summary>
    public partial class MIS_SCM_Indent : WindowElement
    {
        public MIS_SCM_Indent(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_SCM_Indent_VM(ts_code);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            dgPopupcomp.UnselectAll();
            dgPopupDepartment.UnselectAll();
            dgPopupplant.UnselectAll();
            dgEmp.UnselectAll();
            dgPopup2.UnselectAll();
        }       
    }
}
