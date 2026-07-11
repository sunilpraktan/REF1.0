using Reflection.Module.Project.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Module.Project.Views
{
    /// <summary>
    /// Interaction logic for ProjectRoleMaster.xaml
    /// </summary>
    public partial class ProjectRoleMaster : WindowElement
    {
        public ProjectRoleMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PRO_M004_VM(ts_code);
        }
        public ProjectRoleMaster(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PRO_M004_VM(ts_code,doc_no);
        }
        
    }
}
