using Reflection.Modules.PRO.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.PRO.Views
{
    /// <summary>
    /// Interaction logic for PRO_R02.xaml
    /// </summary>
    public partial class PRO_R02 : WindowElement
    {
        public PRO_R02(string ts_code)
        {
            this.DataContext = new PRO_R02_VM(ts_code);
            InitializeComponent();
        }
    }
}
