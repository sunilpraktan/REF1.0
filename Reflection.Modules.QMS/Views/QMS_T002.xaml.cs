using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.QMS.Views
{
    
    public partial class QMS_T002 : WindowElement
    {
        public QMS_T002(string ts_code)
        {
            InitializeComponent();
            //this.DataContext = new InspectionMasterView_VM(ts_code);
        }
        public QMS_T002(string ts_code, string doc_no)
        {
            InitializeComponent();
            //this.DataContext = new InspectionMasterView_VM(ts_code, doc_no);
        }
        
    }
}
