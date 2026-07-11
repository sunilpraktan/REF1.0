using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.SDM.Views;
using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_T001.xaml
    /// </summary>
    public partial class SDM_T001 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public SDM_T001(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new SDM_T001_VM(ts_code,"SN");
            InitializeComponent();
        }

        private void BtnImport_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SDM_WIN_001 OBJ_WIN = new SDM_WIN_001(ts_code_vm);
            OBJ_WIN.Show();
        }
    }
}
