using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for MIS_BOM_MRPReport.xaml
    /// </summary>
    public partial class MIS_BOM_MRPReport : WindowElement
    {
        public MIS_BOM_MRPReport(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_BOM_MRP_VM(ts_code);
        }
        public MIS_BOM_MRPReport(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MIS_BOM_MRP_VM(ts_code,doc_no);
        }
        
    }
}
