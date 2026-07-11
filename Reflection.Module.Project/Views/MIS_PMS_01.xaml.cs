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
using Reflection.WebServices.Gateway;
using Reflection.Module.Project.ViewModels;

namespace Reflection.Module.Project.Views
{
    /// <summary>
    /// Interaction logic for MIS_PMS_01.xaml
    /// </summary>
    public partial class MIS_PMS_01 : WindowElement
    {
        public MIS_PMS_01(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_STD_PMS_1_VM("PMI01");
        }
        
    }
}
