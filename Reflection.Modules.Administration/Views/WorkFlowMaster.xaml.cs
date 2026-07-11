using Reflection.Modules.Administration.ViewModels;
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

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Interaction logic for WorkFlowMaster.xaml
    /// </summary>
    public partial class WorkFlowMaster : WindowElement
    {
        public WorkFlowMaster()
        {
            InitializeComponent();
            this.DataContext = new ADM_M043_VM();
        }
        public WorkFlowMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_M043_VM();
        }
        public WorkFlowMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M043_VM();
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgdoccat.UnselectAll();
                dgdoctype.UnselectAll();
                dgtrans.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }


    }
}
