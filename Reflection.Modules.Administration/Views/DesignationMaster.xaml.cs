using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Interaction logic for DesignationMaster.xaml
    /// </summary>
    public partial class DesignationMaster : WindowElement
    {
        public DesignationMaster()
        {
            InitializeComponent();
            this.DataContext = new ADM_M026_VM();
        }
        public DesignationMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_M026_VM();
        }
        public DesignationMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M026_VM();
        }
    }
}
