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
    /// Description for SalesInquiry
    /// </summary>
    public partial class PostExportTransaction : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the SalesInquiry class.
        /// </summary>
        public PostExportTransaction()
        {
            InitializeComponent();
            this.DataContext = new ECRM_T005_VM();
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgBuyer.UnselectAll();
                //dgData.UnselectAll();
                //dgPartner.UnselectAll();
                //dg.UnselectAll();               
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}