using System;
using System.Windows;
using System.Windows.Controls;
using Reflection.Modules.PRO.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.PRO.Views
{
    /// <summary>
    /// Interaction logic for PRO_T001.xaml
    /// </summary>
    public partial class PRO_T008 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PRO_T008(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            //this.DataContext = new PRO_T008_VM(ts_code);
            
        }
    }
}
