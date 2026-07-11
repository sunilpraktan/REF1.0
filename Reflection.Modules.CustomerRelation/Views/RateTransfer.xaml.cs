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
    /// Description for WritingTest.
    /// </summary>
    public partial class RateTransfer : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the WritingTest class.
        /// </summary>
        public RateTransfer(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ZACC_T001_A_VM(ts_code);
        }
        public RateTransfer(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ZACC_T001_A_VM(ts_code, doc_no);
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpPre_Year.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgParameters_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void dgPopUpConv_lot_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}


