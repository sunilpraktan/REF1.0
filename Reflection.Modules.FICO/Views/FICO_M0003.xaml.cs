using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_M0027.xaml
    /// </summary>
    public partial class FICO_M0003 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public FICO_M0003(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new FICO_M0003_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            InitializeComponent();
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {

                _popupDep.IsOpen = false;
                _popupCurrency.IsOpen = false;
                _popupprofit.IsOpen = false;

            }

        }
    }
}
