using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for Production_Entry.xaml
    /// </summary>
    public partial class Production_Entry : WindowElement
    {
        public Production_Entry(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002_ProdEntryVM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public Production_Entry(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T002_ProdEntryVM(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage obj)
        {
            this.txtbarcodeno.Focus();
        }
        private void dgmachine_Unloaded(object sender, RoutedEventArgs e)
        {
            dgmachine.UnselectAll();
        }

        private void dgproduct_Unloaded(object sender, RoutedEventArgs e)
        {
            dgproduct.UnselectAll();
        }

        private void dgink_Unloaded(object sender, RoutedEventArgs e)
        {
            dgink.UnselectAll();
        }

        private void dgild_Unloaded(object sender, RoutedEventArgs e)
        {
            dgild.UnselectAll();
        }

        private void dgpack_Unloaded(object sender, RoutedEventArgs e)
        {
            dgpack.UnselectAll();
        }
        
    }
}



