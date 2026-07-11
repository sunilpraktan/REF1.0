using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_M0001.xaml
    /// </summary>
    public partial class SDM_M0013 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public SDM_M0013(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new SDM_M0013_VM(ts_code);
            InitializeComponent();
        }
    }
}
