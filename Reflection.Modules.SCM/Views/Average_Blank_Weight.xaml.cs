using Reflection.Modules.SCM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using Reflection.WebServices.Gateway;
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

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Description for Average_Blank_Weight.
    /// </summary>
    public partial class Average_Blank_Weight : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the Average_Blank_Weight class.
        /// </summary>
        public Average_Blank_Weight(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ZSCM_T001_A_VM(ts_code);  
        }
        public Average_Blank_Weight(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new ZSCM_T001_A_VM(ts_code,doc_no);
        }

        
    }
}