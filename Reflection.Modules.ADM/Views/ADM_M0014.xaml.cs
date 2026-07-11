using Reflection.Modules.ADM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Reflection.Modules.ADM.Views
{
    /// <summary>
    /// Interaction logic for ADM_M0014.xaml
    /// </summary>
    public partial class ADM_M0014 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public ADM_M0014(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new ADM_M0014_VM(ts_code, "WF");
            InitializeComponent();
        }
        public ADM_M0014(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M0014_VM(ts_code,"WF");
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgdoccat.UnselectAll();
                dgdoctype.UnselectAll();
                dgtrans.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
