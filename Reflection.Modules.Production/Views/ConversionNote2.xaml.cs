using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for ConversionNote2.xaml
    /// </summary>
    public partial class ConversionNote2 : WindowElement
    {
        public ConversionNote2(string ts_code)
        {
            InitializeComponent();
           this.DataContext=new EPR_T001_VM_CON(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public ConversionNote2(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T001_VM_CON(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "EPR_T001_VM_CON")
            {
                popup_Location.IsOpen = false;
                popup_CompCode.IsOpen = false;
                _popupDocType.IsOpen = false;
            }
        }

        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupBall.UnselectAll();
                //dgPopUpMachine.UnselectAll();
                //dgPopUpMachine2.UnselectAll();
                //dgPopUpCust.UnselectAll();
                //dgPUnit.UnselectAll();

            }

            catch (Exception ex)
            { }
            e.Handled = true;
        }

        

        private void dgParameters_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void PopPara_Unloaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        
    }
}
