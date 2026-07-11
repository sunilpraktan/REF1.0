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
    /// Interaction logic for EmployeeMaster.xaml
    /// </summary>
    public partial class EmployeeMaster : WindowElement
    {
        public EmployeeMaster()
        {
            InitializeComponent();
            this.DataContext = new HRM_M001_VM();
                           
            //Button.Visibility = Visibility.Hidden;
        }
        public EmployeeMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new HRM_M001_VM();

            //Button.Visibility = Visibility.Hidden;
        }
        public EmployeeMaster(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new HRM_M001_VM();

            //Button.Visibility = Visibility.Hidden;
        }


        private void buttonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            //Employee_view.Visibility = Visibility.Collapsed;
            //Employee.Visibility = Visibility.Visible;
            //Button.Visibility = Visibility.Hidden;
        }
       private void buttonClick1(object sender, System.Windows.RoutedEventArgs e)
        {
            //Employee_view.Visibility = Visibility.Visible;
            //Employee.Visibility = Visibility.Collapsed;
            //Button.Visibility = Visibility.Visible;

       }
        
    }
}
