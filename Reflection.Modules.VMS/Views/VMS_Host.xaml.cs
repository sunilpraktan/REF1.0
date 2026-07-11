using GalaSoft.MvvmLight.Ioc;
using Reflection.Modules.VMS.ViewModels;
using Reflection.Presentation.Core.VirtualDesktops;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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
using System.IO;


namespace Reflection.Modules.VMS.Views
{
    /// <summary>
    /// Interaction logic for VMS_Host.xaml
    /// </summary>
    public partial class VMS_Host : UserControl
    {
        public VMS_Host()//string ts_code
        {
            InitializeComponent();
            this.DataContext = new VMS_Host_VM();
        }
        public VMS_Host(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new VMS_Host_VM(ts_code);
        }
        //public VMS_Host(string ts_code, string doc_no)
        //{
        //    InitializeComponent();
        //    this.DataContext = new VMS_Host_VM(ts_code, doc_no);
        //}

        private void Btn_Clk_NewAppointment(object sender, System.Windows.RoutedEventArgs e)
        {

            string userAuth = "Reflection.Modules.VMS.Views.AppointmentByHost"; // this one is path option
            string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.VMS.dll");
            Assembly assembly = Assembly.LoadFile(path1);
            Type type = assembly.GetType(userAuth);
            if (type != null)
            {
                dynamic instance = Activator.CreateInstance(type);
                SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
            }
        }
        
    }
}
