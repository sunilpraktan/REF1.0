using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for MIS_Quality.xaml
    /// </summary>
    public partial class MIS_Quality : WindowElement
    {
        public MIS_Quality(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_Quality_VM(ts_code);
        }
    }
}
