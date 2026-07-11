using Reflection.Modules.PMM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.PMM.Views
{
    /// <summary>
    /// Interaction logic for PPC_R02.xaml
    /// </summary>
    public partial class PMM_R02 : WindowElement
    {
        public PMM_R02(string ts_code)
        {
            this.DataContext = new PMM_R02_VM(ts_code);
            InitializeComponent();
        }
    }
}
