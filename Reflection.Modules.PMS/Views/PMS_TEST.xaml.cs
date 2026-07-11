using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Modules.PMS.Views
{
    /// <summary>
    /// Interaction logic for PMS_TEST.xaml
    /// </summary>
    public partial class PMS_TEST : UserControl
    {
        public string ts_code_vm { get; set; }

        public PMS_TEST()
        {
            InitializeComponent();
        }
        public PMS_TEST(string ts_code)
        {
            ts_code_vm = ts_code;
            InitializeComponent();
        }
        public PMS_TEST(string ts_code, STD_LIST_BE para_obj)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
            }
        }
    }
}
