using Reflection.Modules.ADM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.ADM.Views
{
    /// <summary>
    /// Interaction logic for ADM_M0016.xaml
    /// </summary>
    public partial class ADM_M0016 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public ADM_M0016(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new ADM_M0016_VM(ts_code);
            InitializeComponent();
        }
        public ADM_M0016(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M0016_VM(ts_code);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            dgParamPopup.UnselectAll();


            e.Handled = true;
        }
    }
}
