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
using Reflection.Modules.SCM.ViewModels;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for MIS_SCM.xaml
    /// </summary>
    public partial class MIS_SCM : WindowElement
    {
        public MIS_SCM(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_SCM_VM(ts_code);
        }

    
    }
}
