using System;
using System.Windows;
using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_M0004.xaml
    /// </summary>
    public partial class MM_M0004 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_M0004(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_M0004_VM(ts_code);
            InitializeComponent();
        }
        private void dgItmTypPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgItmTypPopup.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
