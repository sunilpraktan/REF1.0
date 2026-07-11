using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Production.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Input;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for LocalExportCarton.xaml
    /// </summary>
    public partial class LocalExportCarton : WindowElement
    {
        public LocalExportCarton(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T003LocalExportPackingVM(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public LocalExportCarton(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T003LocalExportPackingVM(ts_code,doc_no);
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
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgReportType_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
               // dgReportType.UnselectAll();
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
