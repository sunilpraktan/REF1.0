using Reflection.Modules.ADM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.ADM.Views
{
    /// <summary>
    /// Interaction logic for ADM_M0013.xaml
    /// </summary>
    public partial class ADM_M0013 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public ADM_M0013(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new ADM_M0013_VM(ts_code);
            InitializeComponent();
        }
        public ADM_M0013(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M0013_VM(ts_code);
        }
    }
}
