using Reflection.Presentation.Windows.Controls;

namespace Reflection.Presentation.Widgets
{
    /// <summary>
    /// Interaction logic for CalendarWidgetView.xaml
    /// </summary>
    public partial class CalendarWidgetView : WidgetElement
    {
        public CalendarWidgetView()
        {
            InitializeComponent();
            this.DataContext = new CalendarWidgetViewModel();
        }
    }
}
