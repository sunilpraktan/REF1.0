using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.CustomerRelation.ViewModels;
using System.Windows;
using System;
using System.Windows.Input;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for Activity.xaml
    /// </summary>
    public partial class Activity :WindowElement
    {
        public Activity()
        {
            InitializeComponent();
            this.DataContext = new TSK_T001_C_VM();
        }
        public Activity(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new TSK_T001_C_VM(ts_code);
        }
        public Activity(string ts_code, string doc_no)
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
