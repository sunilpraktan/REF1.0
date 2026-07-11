using Reflection.Modules.HRMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.HRMS.Views
{
    /// <summary>
    /// Interaction logic for HRM_M0005.xaml
    /// </summary>
    public partial class HRM_M0011 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public HRM_M0011(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new HRMS_M0001_VM(ts_code);
            InitializeComponent();
        }
        private void dgPopupDesignation_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupDesignation.UnselectAll();
                dgPopupDepartment.UnselectAll();
                dgPopupLocation.UnselectAll();
                dgPopupCompany.UnselectAll();
                //dgPopuppurchaseorg.UnselectAll();
                //dgPopuppsalesgroup.UnselectAll();
                //dgPopupppurchasegroup.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
