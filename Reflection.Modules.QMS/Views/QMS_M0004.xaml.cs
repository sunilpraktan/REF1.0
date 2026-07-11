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
    /// Interaction logic for QMS_M0004.xaml
    /// </summary>
    public partial class QMS_M0004 : WindowElement
    {
        public QMS_M0004(string ts_code)
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            this.DataContext = new QMS_M030_G_VM(ts_code);
        }
        public QMS_M0004(string ts_code, string doc_no)
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            this.DataContext = new QMS_M030_G_VM(ts_code, doc_no);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "QMS_M030_G_VM")
            {
                qualipopup.IsOpen = false;
            }

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("QMS_M030_G_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
