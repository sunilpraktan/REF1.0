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

namespace Reflection.Modules.Procurement.Views
{
    /// <summary>
    /// Interaction logic for ServiceEntrySheet.xaml
    /// </summary>
    public partial class ServiceEntrySheet  : WindowElement
    {
        public ServiceEntrySheet()
        {
            InitializeComponent();
        }
        public ServiceEntrySheet(string ts_code)
        {
            InitializeComponent();
        }
        public ServiceEntrySheet(string ts_code, string doc_no)
        {
            InitializeComponent();
        }
        
    }
}
