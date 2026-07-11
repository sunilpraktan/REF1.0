using System.Collections.Generic;
using System.Windows;
using Reflection.BusinessEntity;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for WIN_001.xaml
    /// </summary>
    public partial class WIN_001 : Window
    {
        public WIN_001()
        {
            InitializeComponent();
        }
        public WIN_001(List<STD_LIST_BE> list_object)
        {
            InitializeComponent();
            dgData.ItemsSource = list_object;
            
        }

        
    }
}
