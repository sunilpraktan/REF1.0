using Reflection.Presentation.Windows.Controls;
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
using Reflection.Modules.Settings.ViewModels;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.Settings.Views
{
    /// <summary>
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : WindowElement
    {
        public UserSettings()
        {
            InitializeComponent();
            this.DataContext = new SYS_S001VM();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "SYS_S001VM")
            {
                popup_Lang.IsOpen = false;
                popup_DateFormat.IsOpen = false;
                popup_FontFamily.IsOpen = false;
                popup_RoundUp.IsOpen = false;
                popThemes.IsOpen = false;
            }
        }

        private bool isManualEditCommit;
        private void HandleMainDataGridCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (!isManualEditCommit)
            {
                isManualEditCommit = true;
                DataGrid grid = (DataGrid)sender;
                int x = grid.Items.Count;
                grid.CommitEdit(DataGridEditingUnit.Row, true);
                isManualEditCommit = false;
            }
        }
        private void EventPreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) // This Function Prevent Autosuggest LostFocus when Focus shift from TextBox to Popup Grid. You can shift this code to AutoSuggest Control and remove all code from code behind and XAML.
        {
            if ((e.OldFocus.GetType()).Name == "TextBox" && (e.NewFocus.GetType()).Name == "DataGridCell")
            {
                e.Handled = true;
            }
        }
    }
}
