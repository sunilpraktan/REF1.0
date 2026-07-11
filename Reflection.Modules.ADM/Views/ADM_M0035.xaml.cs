using Reflection.Modules.ADM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.ADM.Views
{
    /// <summary>
    /// Interaction logic for ADM_M0035.xaml
    /// </summary>
    public partial class ADM_M0035 : WindowElement
    {
        public string ts_code_vm { get; set; }

        public ADM_M0035(string ts_code)
        {
            //ts_code_vm = ts_code;
            //this.DataContext = new SDM_M0014_VM(ts_code);
            //InitializeComponent();
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
    }
}
