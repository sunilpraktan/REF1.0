using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.CustomerRelation.ViewModels;
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

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for Sample_Response.xaml
    /// </summary>
    public partial class Sample_Response : WindowElement
    {
        public Sample_Response(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T001_C_VM(ts_code);
        }
        public Sample_Response(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T001_C_VM(ts_code, doc_no);
        }
        
    }
}
