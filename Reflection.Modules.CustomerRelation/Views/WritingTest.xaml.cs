using Reflection.Modules.CustomerRelation.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Description for WritingTest. PDI Writing Test Essem
    /// </summary>
    public partial class WritingTest : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the WritingTest class.
        /// </summary>
        public WritingTest(string ts_code)
        {
            InitializeComponent();
            var vm = new ECRM_T003_A_VM(ts_code);
            this.DataContext = vm;
            this.Closed += (s, e) =>
            {
                MachineInterface.StopSessionAndDispose(vm._serialPort, vm._rxBuffer, vm._drainActive, vm._lastByteAt);
            };
        }
        public WritingTest(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ECRM_T003_A_VM(ts_code, doc_no);
        }

        private void dgPopUpmachine_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgPopUpmachine.UnselectAll();
                dgbarcode.UnselectAll();
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
    }
}