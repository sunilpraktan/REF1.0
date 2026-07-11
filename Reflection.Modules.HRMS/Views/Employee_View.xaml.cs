using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.HRMS.ViewModels;
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


namespace Reflection.Modules.HRMS.Views
{
    /// <summary>
    /// Interaction logic for Employee_View.xaml
    /// </summary>
    public partial class Employee_View : WindowElement
    {
        public Employee_View()
        {
            InitializeComponent();
            this.DataContext = new HRM_EmployeeView_VM();
           
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private bool isManualEditCommit;
        private void HandleMainDataGridCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                int x = grid.Items.Count;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                isManualEditCommit = false;
            }
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var msg = new NotificationMessage("HRM_EmployeeView_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }
        private void buttonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            //Empl.Visibility = Visibility.Collapsed;
            //Employee.Visibility = Visibility.Visible;  
        }
        private void buttonClick1(object sender, System.Windows.RoutedEventArgs e)
        {
            //emp.Visibility = Visibility.Visible;
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "HRM_EmployeeView_VM")
            {
                _popupSalutation.IsOpen = false;
                _popupCountry.IsOpen = false;
                _popupnation.IsOpen = false;
                _popupnation1.IsOpen = false;
                _popupPhyDis.IsOpen = false;
                _popupheight.IsOpen = false;
                _popupWeight.IsOpen = false;
                _popupReligion.IsOpen = false;
                _popupcast.IsOpen = false;
                _popupcat.IsOpen = false;
                _popupStstus.IsOpen = false;
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
        }
        private void IsChecked(object sender, RoutedEventArgs e)
        {
            _popupPhyDis.IsOpen = true;
            txtPhyDis.Visibility = Visibility.Visible;
        }
        private void IsUnchecked(object sender, RoutedEventArgs e)
        {
           
            txtPhyDis.Text = null;
            _popupPhyDis.IsOpen = false;
            if (txtPhyDis.Text == "")
            {
                _popupPhyDis.IsOpen = false;
                txtPhyDis.Text = null;
            }
        }
        private void RadioChecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
