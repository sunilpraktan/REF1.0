using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Reflection.Modules.Production.ViewModels;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for MIS_WeightReport.xaml
    /// </summary>
    public partial class MIS_WeightReport : WindowElement
    {
        public MIS_WeightReport(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_WeightReport_VM(ts_code);
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboReport.SelectedValue.ToString() == "R027")
            {
                lblAvgWt.Visibility = Visibility.Collapsed;
                txtweight.Visibility = Visibility.Collapsed;
            }
            else
            {
                lblAvgWt.Visibility = Visibility.Visible;
                txtweight.Visibility = Visibility.Visible;
            }
        }
    }
}
