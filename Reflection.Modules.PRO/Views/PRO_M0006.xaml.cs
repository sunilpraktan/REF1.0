using Reflection.Presentation.Windows.Controls;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.PRO.Views
{
    /// <summary>
    /// Interaction logic for PRO_M0006.xaml
    /// </summary>
    public partial class PRO_M0006 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public PRO_M0006(string ts_code)
        {
            ts_code_vm = ts_code;
            //this.DataContext = new SDM_M0016_VM(ts_code);
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            Tbmaster.SelectionChanged += TabControl_SelectionChanged;
            
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ADM_M028_H_VM")
            {
                _popupPartyID.IsOpen = false;
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (e.Source is TabControl)
            //{
            //    var msg = new NotificationMessage("ADM_M028_H_VM");
            //    this.Dispatcher.BeginInvoke((Action)(() =>
            //    {
            //        NotificationMessageReceived(msg);
            //    }));
            //    e.Handled = true;
            //}
        }
    }
}
