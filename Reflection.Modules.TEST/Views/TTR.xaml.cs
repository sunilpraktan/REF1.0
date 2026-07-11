//using Reflection.Modules.TEST.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.TEST.Views
{
    /// <summary>
    /// Interaction logic for TTR.xaml
    /// </summary>
    public partial class TTR : WindowElement
    {
        public string ts_code_vm { get; set; }
        public TTR(string ts_code)
        {
            ts_code_vm = ts_code;
            InitializeComponent();
        }
    }
}
