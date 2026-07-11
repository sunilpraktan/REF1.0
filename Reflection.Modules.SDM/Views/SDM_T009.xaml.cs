using System;
using System.Windows;
using System.Windows.Controls;
using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_T001.xaml
    /// </summary>
    public partial class SDM_T009 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public SDM_T009(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new SDM_T009_VM(ts_code);
            InitializeComponent();
        }
    }
}
