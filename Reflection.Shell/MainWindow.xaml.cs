using System.Windows;
using Reflection.Shell.ViewModel;

namespace Reflection.Shell
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //Closing += (s, e) => ViewModelLocator.Cleanup();
            this.DataContext = new LoginViewModel();
        }
    }
}