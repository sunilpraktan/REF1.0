using Reflection.Modules.Production.ViewModels;
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

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for ILDChart2.xaml
    /// </summary>
    public partial class ILDChart2 : WindowElement
    {
        public ILDChart2(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T001_ILD_VM(ts_code);
        }
        
    }
    public partial class ILDChart2 : WindowElement
    {
        public ILDChart2(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T001_ILD_VM(ts_code,doc_no);
        }
    }
}
