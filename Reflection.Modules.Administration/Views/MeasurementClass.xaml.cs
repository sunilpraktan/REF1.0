using Reflection.Modules.Administration.ViewModels;
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

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Description for MeasurementClass.
    /// </summary>
    public partial class MeasurementClass : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the MeasurementClass class.
        /// </summary>
        public MeasurementClass()
        {
            InitializeComponent();
            //this.DataContext = new CAL_M009_VM();
        }
        public MeasurementClass(string ts_code)
        {
            InitializeComponent();
            //this.DataContext = new CAL_M009_VM();
        }
        public MeasurementClass(string ts_code, string doc_no)
        {
            InitializeComponent();
            //this.DataContext = new CAL_M009_VM();
        }
    }
}