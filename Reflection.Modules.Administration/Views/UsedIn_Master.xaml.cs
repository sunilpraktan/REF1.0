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
    /// Interaction logic for UsedIn_Master.xaml
    /// </summary>
    public partial class UsedIn_Master : WindowElement
    {
        public UsedIn_Master()
        {
            InitializeComponent();
            this.DataContext = new ZADM_M005_VM();
        }
        public UsedIn_Master(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ZADM_M005_VM();
        }
        public UsedIn_Master(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ZADM_M005_VM();
        }
    }
}
