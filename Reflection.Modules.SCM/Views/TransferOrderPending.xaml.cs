using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Interaction logic for TransferOrderPending.xaml
    /// </summary>
    public partial class TransferOrderPending : WindowElement
    {
        public TransferOrderPending(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new SEL_T004_TOPending_VM(ts_code);
        }
        public TransferOrderPending(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new SEL_T004_TOPending_VM(ts_code,doc_no);
        }
        
    }
}
