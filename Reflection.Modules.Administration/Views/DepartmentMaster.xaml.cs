using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Interaction logic for DepartmentMaster.xaml
    /// </summary>
    public partial class DepartmentMaster : WindowElement
    {
        public DepartmentMaster()
        {
            InitializeComponent();
            this.DataContext = new ADM_M025_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public DepartmentMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ADM_M025_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public DepartmentMaster(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ADM_M025_VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ADM_M025_VM")
            {
                popup_Emp.IsOpen = false;
               
            }
        }
    }
}
