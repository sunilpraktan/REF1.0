using Reflection.Modules.SCM.ViewModels;
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

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for StockChecking.xaml
    /// </summary>
    public partial class StockChecking : WindowElement
    {
        public StockChecking(string ts_code)
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                StockCheckingVM vm = new StockCheckingVM(ts_code);                
                this.DataContext = vm;
            };     

            //this.DataContext = new StockCheckingVM();  
        }
        
    }
}
