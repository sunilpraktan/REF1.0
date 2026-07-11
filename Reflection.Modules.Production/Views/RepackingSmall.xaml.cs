using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for RepackingSmall.xaml
    /// </summary>
    public partial class RepackingSmall : WindowElement
    {
        public RepackingSmall(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T003_RepackingSmall_VM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public RepackingSmall(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T003_RepackingSmall_VM(ts_code,doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage obj)
        {
            this.txtbarcodeno.Focus();
        }

        private void dgproduct_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgproduct.UnselectAll();
                dgproduct.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgink_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgink.UnselectAll();
                dgink.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;

        }
        private void dgmachine_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgmachine.UnselectAll();
                //dgmachine.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
        private void dgild_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgild.UnselectAll();
                dgild.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }
    }
}
