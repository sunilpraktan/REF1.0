using System;
using System.Windows;
using System.Windows.Controls;
using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_T001.xaml
    /// </summary>
    public partial class MM_T009 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_T009(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_T009_VM(ts_code, "PV", "PV");
            InitializeComponent();
        }
    }
}
