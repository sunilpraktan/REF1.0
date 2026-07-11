using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for BreakDownReason.xaml
    /// </summary>
    public partial class BreakDownReason : WindowElement
    {
        public BreakDownReason(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PMT_M001_VM(ts_code);
        }
        public BreakDownReason(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PMT_M001_VM(ts_code,doc_no);
        }
        
    }
}
