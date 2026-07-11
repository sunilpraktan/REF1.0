using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.SCM.ViewModels;

namespace Reflection.Modules.SCM.Views
{
    /// <summary>
    /// Description for Gate_Entry.
    /// </summary>
    public partial class Gate_Entry : WindowElement
    {
        /// <summary>
        /// Initializes a new instance of the Gate_Entry class.
        /// </summary>
        public Gate_Entry(string ts_code)
        {
            InitializeComponent();
            this.DataContext = new MM_T004_VM(ts_code);
        }
        public Gate_Entry(string ts_code,string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T004_VM(ts_code,doc_no);
        }

        
    }
}