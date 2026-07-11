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
    /// Interaction logic for MIS_Tour_Management.xaml
    /// </summary>
    public partial class MIS_Tour_Management : WindowElement
    {
        public MIS_Tour_Management()
        {
            InitializeComponent();
            this.DataContext = new MIS_Tour_Voucher_VM();
        }
        public MIS_Tour_Management(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_Tour_Voucher_VM();
        }
    }
}
