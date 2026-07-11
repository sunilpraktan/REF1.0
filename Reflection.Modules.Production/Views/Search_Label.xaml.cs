using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for Production_Entry.xaml
    /// </summary>
    public partial class Search_Label : WindowElement
    {
        public Search_Label(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new Search_LabelVM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage obj)
        {
            this.txtbarcodeno.Focus();
        }
        private void dgPopup_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupBall.UnselectAll();
                //dgPopupMachine.UnselectAll();
                //dgPopupCustomer.UnselectAll();
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

        private void dgPopupSalesOrder_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgPopupSalesOrder.UnselectAll();
                //dgPopupSalesOrder.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }


    }
}
