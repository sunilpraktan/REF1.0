using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.QMS.Views
{
    public partial class QMS_R02 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public QMS_R02(string ts_code)
        {
            ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new QMS_R02_VM(ts_code);
        }
    }
}
