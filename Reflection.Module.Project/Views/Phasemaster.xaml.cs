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
using Reflection.Presentation.Windows.Controls;
using Reflection.Module.Project.ViewModels;

namespace Reflection.Module.Project.Views
{
    /// <summary>
    /// Interaction logic for Phasemaster.xaml
    /// </summary>
    public partial class Phasemaster : WindowElement
    {
        public Phasemaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PRO_M003_VM(ts_code);
        }
        public Phasemaster(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PRO_M003_VM(ts_code,doc_no);
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
