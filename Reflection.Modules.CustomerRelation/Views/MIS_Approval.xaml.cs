using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.CustomerRelation.ViewModels;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for MIS_Approval.xaml
    /// </summary>
    public partial class MIS_Approval : WindowElement
    {
        public MIS_Approval()
        {
            InitializeComponent();
            this.DataContext = new MIS_Approval_VM();
        }
        public MIS_Approval(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_Approval_VM();
        }
    }
}
