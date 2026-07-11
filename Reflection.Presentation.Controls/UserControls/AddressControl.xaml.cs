using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.GEN;
using Reflection.Presentation.Controls.ViewModel;

namespace Reflection.Presentation.Controls.UserControls
{
    /// <summary>
    /// Interaction logic for AddressControl.xaml
    /// </summary>
    public partial class AddressControl : Window
    {
        public string ts_code_vm { get; set; }
        public string uid { get; set; }
        GEN_M0011 obj_address = new GEN_M0011();   
        public AddressControl(string ts_code,string uid,GEN_M0011 OBJ_ADD)
        {
            ts_code_vm = ts_code;
            obj_address = OBJ_ADD;
            this.DataContext = new AddessControl_VM(ts_code, uid, OBJ_ADD);
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm && msg.Sender.ToString() == uid)
            {
                //popup_AccountingGroup.IsOpen = false;

            }
        }
    }
}
