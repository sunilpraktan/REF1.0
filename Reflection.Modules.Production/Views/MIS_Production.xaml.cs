using Reflection.Presentation.Windows.Controls;
using System.Windows;
using System.Windows.Controls;
using Reflection.Modules.Production.ViewModels;

namespace Reflection.Modules.Production.Views
{
    /// <summary>
    /// Interaction logic for MIS_Production.xaml
    /// </summary>
    public partial class MIS_Production : WindowElement
    {
        public MIS_Production(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MIS_Production_VM(ts_code);

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PartyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {

        }
    }
}
