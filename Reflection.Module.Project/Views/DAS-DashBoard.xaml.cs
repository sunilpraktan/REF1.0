using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Windows.Controls;
using Reflection.Modules.Project.ViewModels;
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

namespace Reflection.Module.Project.Views
{
    /// <summary>
    /// Interaction logic for DAS_DashBoard.xaml
    /// </summary>
    public partial class DAS_DashBoard : WindowElement
    {

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set
            {
                if (_SelectedTabControlIndex != value)
                {
                    _SelectedTabControlIndex = value;
                   // RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }

        public DAS_DashBoard()
        {
            InitializeComponent();
            if (SelectedTabControlIndex == 0)
            {
                this.DataContext = new RND_T010_A_VM();
            }
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            TabTB.SelectionChanged += TabControl_SelectionChanged;
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "RND_T010_VM")
            {
                popup_TestBedNo.IsOpen = false;
                popup_Project.IsOpen = false;
                popup_EngineModel.IsOpen = false;
                popup_EngineNo.IsOpen = false;
                popup_TestType.IsOpen = false;
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
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {                
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    if (TabTB.SelectedIndex == 0)
                    {
                        this.DataContext = new RND_T010_A_VM();
                    }
                    else if (TabTB.SelectedIndex == 1)
                    {
                        this.DataContext = new RND_T010_VM();
                    }
                }));
                e.Handled = true;
            }
        }
    }
}
