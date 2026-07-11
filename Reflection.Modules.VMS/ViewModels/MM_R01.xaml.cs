using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_R01.xaml
    /// </summary>
    public partial class MM_R01 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_R01(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new MIS_STD_MM_2_VM(ts_code_vm);
            InitializeComponent();
        }
    }
}
