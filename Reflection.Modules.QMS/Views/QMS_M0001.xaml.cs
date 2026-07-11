using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
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

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for QMS_M0001.xaml
    /// </summary>
    public partial class QMS_M0001 : WindowElement
    {
        public string ts_code_vm { get; set; }

        public QMS_M0001()
        {
            InitializeComponent();
            this.DataContext = new QMS_M0040_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged; 
        }
        public QMS_M0001(string ts_code)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new QMS_M0040_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
        }
        public QMS_M0001(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new QMS_M0040_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                popupinsptp.IsOpen = false;
                popupitem.IsOpen = false;
                popupsp.IsOpen = false;
            }

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage(ts_code_vm);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
