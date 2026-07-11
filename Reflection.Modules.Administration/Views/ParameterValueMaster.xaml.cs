using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows;

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Description for ParameterValueMaster.
    /// </summary>
    public partial class ParameterValueMaster : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the ParameterValueMaster class.
        /// </summary>
        public ParameterValueMaster()
        {
            InitializeComponent();
            this.DataContext = new ADM_M030_VM();
        }
        public ParameterValueMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_M030_VM();
        }
        public ParameterValueMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M030_VM();
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {            
            dgParamPopup.UnselectAll();
            

            e.Handled = true;
        }
    }
}