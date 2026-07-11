using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.CustomerRelation.ViewModels;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.CustomerRelation.Views
{
    /// <summary>
    /// Interaction logic for InkAndTipMatching.xaml
    /// </summary>
    public partial class InkAndTipMatching : WindowElement
    {
        public string ts_code_vm { get; set; }
        public InkAndTipMatching(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new ZCRM_T004_VM("TC", ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public InkAndTipMatching(string ts_code)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new ZCRM_T004_VM("TC", ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            //dgContact_Per_nm.UnselectAll();
            //dgitem.UnselectAll();
            //dgparty.UnselectAll();
            //dgPaymethod.UnselectAll();
            //dgPopupunit.UnselectAll();
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ZCRM_T004_VM")
            {
                //PopUpContact_Per_nm.IsOpen = false;
            }
        }
    }
}
