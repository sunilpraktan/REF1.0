using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.Production.ViewModels;
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

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for LocalCarton2.xaml
    /// </summary>
    public partial class LocalCarton2 : WindowElement
    {
        public LocalCarton2(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new EPR_T003_LocalCarton_VM2(ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public LocalCarton2(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new EPR_T003_LocalCarton_VM2(ts_code,doc_no);
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
                //  dgReportType.UnselectAll();
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

        private void dgmachine_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgmachine.UnselectAll();
            }
            catch (Exception ex)
            { }
            e.Handled = true;
        }

        private void dgmoperator_Unloaded(object sender, RoutedEventArgs e)
        {
            dgmoperator.UnselectAll();
        }
        
    }
}
