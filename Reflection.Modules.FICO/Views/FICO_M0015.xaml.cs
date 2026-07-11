using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_M0027.xaml
    /// </summary>
    public partial class FICO_M0015 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public FICO_M0015(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new FICO_M0015_VM(ts_code);
            InitializeComponent();
        }
    }
}
