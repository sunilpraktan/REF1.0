using System;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.CustomerRelation.ViewModels;
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
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for ExpensesVoucher.xaml
    /// </summary>
    public partial class Closure : WindowElement
    {
        public Closure(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new CRM_T004_VM(ts_code);
        }

        private void DgPopUpUnloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgSalesPerson.UnselectAll();
                //dgMonthAndYear.UnselectAll();
                dgPopupplant.UnselectAll();
                dgCompany.UnselectAll();
                dgsaleorgnisation.UnselectAll();
                dgSalesGroup.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
