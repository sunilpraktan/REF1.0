using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;

using System.Windows;
using System.Windows.Input;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for CRMActivity2.xaml
    /// </summary>
    public partial class CRMActivity2 : WindowElement
    {
        public CRMActivity2()
        {
            InitializeComponent();
            this.DataContext = new TSK_T001_C_VM();
        }
        public CRMActivity2(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new TSK_T001_C_VM(ts_code);
        }
        public CRMActivity2(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new TSK_T001_C_VM(ts_code, doc_no);
        }

        private void DgPopUpUnloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupEmp.UnselectAll();
                dgPopupRefSoNo.UnselectAll();
                dgPopupParty.UnselectAll();
                dgPopupParent.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        
    }
}
