using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using Reflection.Modules.Navigation;
using Reflection.Presentation.Windows.Controls;
using Reflection.Shell.ViewModel;

namespace Reflection.Shell.Views
{
   
    public partial class Login : WindowElement
    {
        #region · Constructors ·

        public Login()
        {
            InitializeComponent();

            this.DataContext = new LoginViewModel();
        }

        #endregion
    }
}
