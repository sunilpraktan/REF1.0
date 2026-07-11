using System;
using System.Windows;

using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.Procurement.ViewModels;
using System.Windows.Input;

namespace Reflection.Modules.Procurement.Views
{
    /// <summary>
    /// Interaction logic for PurchaseOrderInternal.xaml
    /// </summary>
    public partial class PurchaseOrderInternal : WindowElement
    {
        public PurchaseOrderInternal(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new PUR_T002_AVM_Internal(ts_code);
        }
        public PurchaseOrderInternal(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new PUR_T002_AVM_Internal(ts_code, doc_no);
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            dgbuyer.UnselectAll();
            dgSupplier.UnselectAll();
            dgreceivinplant.UnselectAll();
            dgPopupParty.UnselectAll();
        }
        
    }
}
