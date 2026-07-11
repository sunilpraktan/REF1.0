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
using Reflection.Modules.Administration.ViewModels;
using Reflection.Presentation.Windows.Controls;

namespace Reflection.Modules.Administration.Views
{
    /// <summary>
    /// Description for InkMaster.
    /// </summary>
    public partial class InkMaster : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the InkMaster class.
        /// </summary>
        public InkMaster(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new ZADM_M006_VM(ts_code);
        }
    }
}