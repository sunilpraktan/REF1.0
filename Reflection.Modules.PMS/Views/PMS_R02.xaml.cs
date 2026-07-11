using Reflection.Modules.PMS.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.PMS.Views
{
    /// <summary>
    /// Interaction logic for PMS_R02.xaml
    /// </summary>
    public partial class PMS_R02 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PMS_R02(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new PMS_R02_VM(ts_code);
            InitializeComponent();
        }
    }
}
