using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.SCM.ViewModels;
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
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Description for ProductConversion_Essem.
    /// </summary>
    public partial class ProductConversion_Essem : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the ProductConversion_Essem class.
        /// </summary>
        public ProductConversion_Essem(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_GC_VM(ts_code);
        }
        public ProductConversion_Essem(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T001_GC_VM(ts_code,doc_no);
        }
        private void dgmov_tp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgmov_tp.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        
    }
}