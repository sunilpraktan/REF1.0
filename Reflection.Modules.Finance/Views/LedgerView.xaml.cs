using Reflection.BusinessEntity;
using Reflection.Modules.Finance.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for LedgerView.xaml
    /// </summary>
    public partial class LedgerView : WindowElement
    {
        
        public LedgerView(object DocumentNumber)
        {
            InitializeComponent();
            this.DataContext = new GLAccountPostingBL(Convert.ToString( DocumentNumber));
        }
        public LedgerView(string ts_code, object DocumentNumber)
        {
            InitializeComponent();
            this.DataContext = new GLAccountPostingBL(Convert.ToString(DocumentNumber));
        }
        

    }
}
