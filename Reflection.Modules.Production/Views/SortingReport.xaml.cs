using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Description for SortingReport.
    /// </summary>
    public partial class SortingReport : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the SortingReport class.
        /// </summary>
        public SortingReport(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ESO_T001_ReportVM(ts_code);    
        }
    }
}