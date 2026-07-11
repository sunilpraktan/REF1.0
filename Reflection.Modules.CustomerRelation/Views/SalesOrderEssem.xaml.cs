using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Controls;
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
    public partial class SalesOrderEssem : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the SalesOrderMaster class.
        /// </summary>
        public SalesOrderEssem()
        {
            InitializeComponent();
            this.DataContext = new SalesOrderEssemVM();
        }


        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgDocType.UnselectAll();
                //dgPopupParty.UnselectAll();
                //dgShipToParty.UnselectAll();
                //dgNotifyingParty.UnselectAll();
                //dgCurrency.UnselectAll();
                //dgPopupRefDocNo.UnselectAll();
                //dgBuyer.UnselectAll();
                //dgSalesPerson.UnselectAll();
                //dgPayTerms.UnselectAll();
                //dgPopupBillAdddress.UnselectAll();
                //dgPopupDeliveryAdddress.UnselectAll();
                //dgPopupRParty.UnselectAll();
                //dgPopupBank.UnselectAll();
                //dgPopupNastroBank.UnselectAll();
                //dgsaleorgnisation.UnselectAll();
                //dgSalesGroup.UnselectAll();
                //dgIncoterm.UnselectAll();
                //dgplant.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }


    }
}


