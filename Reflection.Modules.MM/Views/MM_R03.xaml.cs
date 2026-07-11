using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_R03.xaml
    /// </summary>
    public partial class MM_R03 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_R03(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_R03_VM(ts_code);
            InitializeComponent();
        }
    }
}
