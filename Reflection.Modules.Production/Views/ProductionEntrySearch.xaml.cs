using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for ProductionEntrySearch.xaml
    /// </summary>
    public partial class ProductionEntrySearch : WindowElement
    {
        public ProductionEntrySearch(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002_PE_SearchVM(ts_code);
        }
        public ProductionEntrySearch(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002_PE_SearchVM(ts_code,doc_no);
        }
        
    }
}
