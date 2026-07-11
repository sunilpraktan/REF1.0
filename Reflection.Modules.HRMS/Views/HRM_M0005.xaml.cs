using Reflection.Modules.HRMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.HRMS.Views
{
    /// <summary>
    /// Interaction logic for HRM_M0005.xaml
    /// </summary>
    public partial class HRM_M0005 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public HRM_M0005(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new HRMS_M0005_VM(ts_code);
            InitializeComponent();
        }
    }
}
