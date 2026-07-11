using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows.Controls;


namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Interaction logic for WithHoldingTaxMaster.xaml
    /// </summary>
    public partial class WithHoldingTaxMaster : WindowElement
    {
        public WithHoldingTaxMaster()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster.SelectionChanged += TabControl_SelectionChanged;
            this.DataContext = new ACC_M025_VM();
        }
        public WithHoldingTaxMaster(string ts_code)
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster.SelectionChanged += TabControl_SelectionChanged;
            this.DataContext = new ACC_M025_VM();
        }
        public WithHoldingTaxMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster.SelectionChanged += TabControl_SelectionChanged;
            this.DataContext = new ACC_M025_VM();
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ACC_M025_VM")
            {
                
                _popupcountry.IsOpen = false;

            }

        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("ACC_M025_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void Tbmaster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
