using Reflection.Modules.VMS.ViewModels;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Modules.VMS.Views
{
    /// <summary>
    /// Interaction logic for VMS_MasterPage.xaml
    /// </summary>
    public partial class VMS_MasterPage : WindowElement
    {


        public VMS_MasterPage()
        {
            InitializeComponent();
            this.DataContext = new VMS_MasterPage_VM();
        }
        public VMS_MasterPage(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new VMS_MasterPage_VM(ts_code);
        }

        //public VMS_MasterPage()
        //{
        //    InitializeComponent();
        //    this.DataContext = new VMS_MasterPage_VM("ts_code", "doc_no");
        //}

        private void Btn_Clk_AppointmentByHost_Current(object sender, System.Windows.RoutedEventArgs e)
        {
            AppointmentByHostWindow_Current.Visibility = Visibility.Visible;
            //AppointmentByHostWindow_History.Visibility = Visibility.Collapsed;

        }

        private void Btn_Clk_AppointmentByHost_History(object sender, System.Windows.RoutedEventArgs e)
        {       
            AppointmentByHostWindow_History.Visibility = Visibility.Visible;
            //AppointmentByHostWindow_Current.Visibility = Visibility.Collapsed; 
        }


        //private void Btn_Clk_Act(object sender, System.Windows.RoutedEventArgs e)
        //{
        //    ActivityWindow.Visibility = Visibility.Visible;
        //    OpportunityWindow.Visibility = Visibility.Collapsed;
        //    LeadWindow.Visibility = Visibility.Collapsed;
        //}
       
    }
}
