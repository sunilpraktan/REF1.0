using Reflection.Modules.PMS.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.PMS.Views
{
    public partial class PMS_R01 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PMS_R01(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new MIS_STD_MM_2_VM("MMI19");
            InitializeComponent();
        }
    }
}
