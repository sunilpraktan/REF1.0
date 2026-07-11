using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_M0001.xaml
    /// </summary>
    public partial class SDM_M0015 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public SDM_M0015(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new SDM_M0015_VM(ts_code);
            InitializeComponent();
        }
        
    }
}
