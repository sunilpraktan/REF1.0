using Reflection.Modules.Navigation;
using Reflection.Presentation.Core.ViewModel;
using Reflection.Presentation.Windows.Controls;
using Reflection.Shell.ViewModel;

namespace Reflection.Shell.Views
{
   
    public partial class About : WindowElement
    {
        public About(INavigationViewModel viewModel)
        {
            InitializeComponent();

            this.DataContext = viewModel;
        }
    }
}
