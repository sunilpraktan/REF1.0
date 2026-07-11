using Reflection.Modules.Finance.ViewModels;
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

namespace Reflection.Modules.Finance.Views
{
    /// <summary>
    /// Interaction logic for MIS_Finance4.xaml
    /// </summary>
    public partial class MIS_Finance4 : WindowElement
    {
        public MIS_Finance4()
        {
            InitializeComponent();
            this.DataContext = new MIS_Finance4_VM();
        }
        public MIS_Finance4(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_Finance4_VM();
        }
    }
}
