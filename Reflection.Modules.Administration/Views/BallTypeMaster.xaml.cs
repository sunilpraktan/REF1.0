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
    /// Interaction logic for BallType.xaml
    /// </summary>
    public partial class BallTypeMaster : WindowElement
    {
        public BallTypeMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ZADM_M002_VM(ts_code);
        }
    }
}
