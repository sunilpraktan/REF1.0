using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_M0003.xaml
    /// </summary>
    public partial class MM_M0009 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public MM_M0009(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_M0009_VM(ts_code);
            InitializeComponent();
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            dgParamPopup.UnselectAll();


            e.Handled = true;
        }

    }
}
