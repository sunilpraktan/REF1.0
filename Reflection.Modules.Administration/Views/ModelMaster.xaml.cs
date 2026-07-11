using Reflection.Modules.Administration.ViewModels;
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

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Description for ModelMaster.
    /// </summary>
    public partial class ModelMaster : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the ModelMaster class.
        /// </summary>
        public ModelMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ZADM_M009_VM(ts_code);
        }

        private void DgPopUp_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgwiresize.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}