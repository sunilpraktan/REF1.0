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
    /// Interaction logic for MIS_Pro_MFG.xaml
    /// </summary>
    public partial class MIS_Pro_MFG : WindowElement
    {
        public MIS_Pro_MFG(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_Pro_MFG_VM(ts_code);
        }
        public MIS_Pro_MFG(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MIS_Pro_MFG_VM(ts_code,doc_no);
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PartyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
