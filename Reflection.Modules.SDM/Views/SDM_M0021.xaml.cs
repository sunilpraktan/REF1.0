using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_M0021.xaml
    /// </summary>
    public partial class SDM_M0021 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;

        public SDM_M0021(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new SDM_M0021_VM(ts_code,"102");
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_M0021(string ts_code,object OBJ_PARA)
        {
            ts_code_vm = ts_code;
            this.DataContext = new SDM_M0021_VM(ts_code, "102", OBJ_PARA);
            InitializeComponent();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == ts_code_vm)
            {
                //popup_AccountingGroup.IsOpen = false;

            }
        }
        
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
                var msg = new NotificationMessage(ts_code_vm);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void TxtAge_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAge.Text)) // && string.IsNullOrWhiteSpace(dtpDOEB.Text)
            {
                if (Convert.ToInt32(txtAge.Text).GetType() == typeof(int))
                {
                    //int intAge = Convert.ToInt32(txtAge.Text);
                    //DateTime now = new DateTime((DateTime.Now.Year - intAge), 6, DateTime.Now.Day);
                    //dtpDOEB.SelectedDate = DateTime.Parse(now.ToShortDateString());
                    //DateTime nowd = DateTime.Now.Date.AddYears(-Convert.ToInt32(txtAge.Text));
                    //nowd = new DateTime(nowd.Year, 6, nowd.Day);
                    //dtpDOEB.SelectedDate = nowd;
                }
                else
                {
                    MessageBox.Show("Input correct value for approximate age");
                }
            }
        }
    }
}
