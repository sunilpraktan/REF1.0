using GalaSoft.MvvmLight.Messaging;
using Reflection.Module.Project.ViewModels;
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

namespace Reflection.Module.Project.Views
{
    /// <summary>
    /// Interaction logic for Project_Master01.xaml
    /// </summary>
    public partial class Project_Master01 : WindowElement
    {
        public Project_Master01(string ts_code)
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            this.DataContext = new PPC_M0002_VM(ts_code);
        }
        public Project_Master01(string ts_code, string doc_no)
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            this.DataContext = new PPC_M0002_VM(ts_code, doc_no);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "PPC_M0002_VM")
            {

            }

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("PPC_M0002_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
    }
}
