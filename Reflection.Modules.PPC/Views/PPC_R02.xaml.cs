using Reflection.Modules.PPC.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.PPC.Views
{
    /// <summary>
    /// Interaction logic for PPC_R02.xaml
    /// </summary>
    public partial class PPC_R02 : WindowElement
    {
        public PPC_R02(string ts_code)
        {
            this.DataContext = new PPC_R02_VM(ts_code);
            InitializeComponent();
        }
    }
}
