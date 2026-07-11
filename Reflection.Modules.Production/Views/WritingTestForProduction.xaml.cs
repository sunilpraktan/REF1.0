using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Description for WritingTestForProduction. Essem
    /// </summary>
    public partial class WritingTestForProduction : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the WritingTestForProduction class.
        /// </summary>
        public WritingTestForProduction(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T003_A_VM_PROD(ts_code);
        }
        public WritingTestForProduction(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T003_A_VM_PROD(ts_code,doc_no);
        }
        private void dgPopUpmachine_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpmachine.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void dgPopUpConv_lot_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpConv_lot.UnselectAll();

            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgData_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var uiElement = e.OriginalSource as UIElement;
            if (e.Key == Key.Enter && uiElement != null)
            {
                e.Handled = true;
                uiElement.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
            }
            try
            {
                if (e.Key == Key.Enter)
                {
                    e.Handled = true;

                    dgData.BeginEdit();
                    
                }
            }
            catch (Exception ex)
            {
                //MessageBox(ex.Message, "Error", MessageType.Error);
            }
        }
        
    }
}