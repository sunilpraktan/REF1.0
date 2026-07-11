using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_R02.xaml
    /// </summary>
    public partial class MM_R06 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_R06(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_R02_VM(ts_code);
            InitializeComponent();
        }
    }
}
