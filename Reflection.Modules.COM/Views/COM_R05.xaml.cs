using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.COM.ViewModels;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.COM.Views
{
    public partial class COM_R05 : WindowElement
    {
        public COM_R05(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new COM_R05_VM();
        }
       

    }
}
