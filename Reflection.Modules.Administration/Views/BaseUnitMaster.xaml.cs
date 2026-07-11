using Reflection.Modules.Administration.ViewModels;
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


namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Description for BaseUnitMaster.
    /// </summary>
    public partial class BaseUnitMaster : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the BaseUnitMaster class.
        /// </summary>
        public BaseUnitMaster()
        {
            InitializeComponent();
           // this.DataContext = new CAL_M011_VM();    
        }
    }
}