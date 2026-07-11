using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Windows.Controls;
using Reflection.WebServices.Gateway;
using System;
using System.Windows;
using Reflection.BusinessEntity;


namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Description for UserMaster.
    /// </summary>
    //REFLECTIONDBEntities dbContext = new REFLECTIONDBEntities();
    public partial class UserMaster : WindowElement
    {
        /// <summary>
        WebServiceRepository<MultipleContext_ADM_M010> repositoryM = new WebServiceRepository<MultipleContext_ADM_M010>();
        /// </summary>
        public UserMaster()
        {
            InitializeComponent();
            this.DataContext = new ADM_M010_VM();
        }
        public UserMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_M010_VM();
        }
        public UserMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M010_VM();
        }

        private void dgPopupEmp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupEmp.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgPopupUserType_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupUserType.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

    }

}