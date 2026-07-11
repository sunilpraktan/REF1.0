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
    public partial class MM_T008 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_T008(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_T008_VM(ts_code);
            InitializeComponent();
        }
        public MM_T008(string ts_code, string doc_no)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_T008_VM(ts_code,doc_no);
            InitializeComponent();
        }
    }
}
