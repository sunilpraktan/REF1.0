using Reflection.Modules.ADM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.ADM.Views
{
    /// <summary>
    /// Interaction logic for ADM_M0011.xaml
    /// </summary>
    public partial class ADM_M0011 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public ADM_M0011(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new ADM_M0011_VM(ts_code);
            InitializeComponent();
        }
        public ADM_M0011(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M0011_VM(ts_code);
        }
        private void dgPopupMeasurCls_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupMeasurCls.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
