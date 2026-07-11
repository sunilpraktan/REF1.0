using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Windows.Controls;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Description for SalesOrderMaster.
    /// </summary>
    public partial class Sample_Request : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the SalesOrderMaster class.
        /// </summary>
        public Sample_Request(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new SEL_T001_VM_SampleRequest("SR", ts_code);    
        }
        public Sample_Request(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new SEL_T001_VM_SampleRequest("SR",ts_code, doc_no);
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                
                dgPopupParty.UnselectAll();
               
              
                //dgCurrency.UnselectAll();
              
                dgBuyer.UnselectAll();
                dgSalesPerson.UnselectAll();
             
               
                dgPopupBillAdddress.UnselectAll();
             
           
            
                dgsaleorgnisation.UnselectAll();
                dgSalesGroup.UnselectAll();
              
                dgplant.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        
    }
}