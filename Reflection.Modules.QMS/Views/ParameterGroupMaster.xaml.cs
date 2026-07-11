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
    /// Interaction logic for ParameterGroupMaster.xaml
    /// </summary>
    public partial class ParameterGroupMaster : WindowElement
    {
        public ParameterGroupMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new QMS_M009_F_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
        }
        public ParameterGroupMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new QMS_M009_F_VM(ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "QMS_M009_F_VM")
            {
                catpopup.IsOpen = false;
                
            }
           
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("QMS_M009_F_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        
    }
}
