using Reflection.Modules.Administration.ViewModels;
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
using System.IO;
using Microsoft.Win32;

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Interaction logic for MakeMaster.xaml
    /// </summary>
    public partial class MakeMaster : WindowElement
    {
        public MakeMaster()
        {
            InitializeComponent();
            this.DataContext = new ADM_M032_VM();
        }
        public MakeMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_M032_VM();
        }
        public MakeMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M032_VM();
        }
    }
}
