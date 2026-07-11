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
    /// Interaction logic for LabelGenerationUpdate.xaml
    /// </summary>
    public partial class LabelGenerationUpdate : WindowElement
    {
        public LabelGenerationUpdate(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002_LabelUpdate_VM(ts_code);
        }
        public LabelGenerationUpdate(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002_LabelUpdate_VM(ts_code,doc_no);
        }

        private void dgmachine_Unloaded(object sender, RoutedEventArgs e)
        {
            dgmachine5.UnselectAll();
        }
    }
}
