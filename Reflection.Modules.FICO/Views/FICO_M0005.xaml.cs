using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.FICO.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;

namespace Reflection.Modules.FICO.Views
{
    /// <summary>
    /// Interaction logic for FICO_M0027.xaml
    /// </summary>
    public partial class FICO_M0005 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public FICO_M0005(string ts_code)
        {
            
            ts_code_vm = ts_code;
            this.DataContext = new FICO_M0005_VM(ts_code);
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster.SelectionChanged += TabControl_SelectionChanged;
            
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "FICO_M0005_VM")
            {

                _popupcountry.IsOpen = false;

            }

        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("FICO_M0005_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
