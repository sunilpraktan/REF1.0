using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FR_R01.xaml
    /// </summary>
    public partial class FICO_R01 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public FICO_R01(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new MIS_STD_MM_2_VM(ts_code_vm);
            InitializeComponent();
        }
    }
}
