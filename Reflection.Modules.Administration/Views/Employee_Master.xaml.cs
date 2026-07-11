using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Description for EmployeeMaster.
    /// </summary>
    public partial class Employee_Master : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the EmployeeMaster class.         
        /// </summary>
        public Employee_Master()
        {
            InitializeComponent();
            this.DataContext = new ADM_M024_VM();
        }
        public Employee_Master(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_M024_VM();
        }
        public Employee_Master(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M024_VM();
        }

        private void dgPopupDesignation_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupDesignation.UnselectAll();
                //dgPopupDepartment.UnselectAll();
                //dgPopupLocation.UnselectAll();
                //dgPopupCompany.UnselectAll();
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