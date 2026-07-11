using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_U0002.xaml
    /// </summary>
    public partial class FICO_U0002 : UserControl
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public FICO_U0002(string ts_code)
        {
            this.ts_code_vm = ts_code;

            this.DataContext = new FICO_T006_VM("PR", ts_code,"","POS");
            InitializeComponent();
        }
        public FICO_U0002(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new FICO_T006_VM("PR", ts_code, doc_no);
        }
    }
}
