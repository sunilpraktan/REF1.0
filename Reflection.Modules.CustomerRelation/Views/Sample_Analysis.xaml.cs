using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Windows.Controls;
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
    /// Interaction logic for Sample_Analysis.xaml
    /// </summary>
    public partial class Sample_Analysis : WindowElement
    {
        public Sample_Analysis(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T001_A_VM(ts_code);
        }
        public Sample_Analysis(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T001_A_VM(ts_code, doc_no);
        }
        private void dgPopupPlant_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopupPlant.UnselectAll();
                dgsaleorgnisation.UnselectAll();
                dgSalesGroup.UnselectAll();
                dgSampleFrom.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void txtPartnerID_LostFocus(object sender, RoutedEventArgs e)
        {
            // Pending
            //BindingExpression be = txtPartnerID.GetBindingExpression(TextBox.TextProperty);
            //be.UpdateSource();
        }

        private void txtwrtlenreq_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtConclusion_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        
    }

}
