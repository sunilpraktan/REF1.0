using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.PPC.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using Reflection.WebServices.Gateway;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.PPC.Views
{
    /// <summary>
    /// Interaction logic for PPC_C001.xaml
    /// </summary>
    public partial class PPC_C001 : WindowElement
    {
        
        public PPC_C001(string ts_code, STD_LIST_BE STD_LIST_OBJ)
        {
            InitializeComponent();
            //this.DataContext = new PPC_C001_VM(STD_LIST_OBJ);
            this.DataContext = new PPC_T002_VM(ts_code, STD_LIST_OBJ.doc_cat, STD_LIST_OBJ.doc_type, STD_LIST_OBJ);
            //Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            //if (msg.Notification == this.ts_code_vm)
            //{

            //}
        }
    }
}
