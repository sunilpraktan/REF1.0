using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.MM.ViewModels;


namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_R04.xaml
    /// </summary>
    public partial class MM_R04 : WindowElement
    {
        
        private string ts_code_local;
        public MM_R04(string ts_code)
        {
            this.ts_code_local = ts_code;
            InitializeComponent();
            this.DataContext = new MM_R04_VM(ts_code);
        }
       
    }
}
