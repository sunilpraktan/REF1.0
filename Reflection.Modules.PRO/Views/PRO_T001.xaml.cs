using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.PRO.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Forms;
using System.Windows.Input;

namespace Reflection.Modules.PRO.Views
{
    /// <summary>
    /// Interaction logic for PRO_T001.xaml
    /// </summary>
    public partial class PRO_T001 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public string dgKey { get; set; } = null; // REF_INFO: added this to get Key pressed because RoutedEventArgs of HandleDataGridGotFocus handler if not able to identify which Key press, so using this method we identify key and once Handler complete then reset to null. 
        public PRO_T001(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new PRO_T001_VM("RQ",ts_code);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            InitializeComponent();
        }
        public PRO_T001(string ts_code,string doc_no)
        {
            ts_code_vm = ts_code;
            this.DataContext = new PRO_T001_VM("RQ", ts_code, doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            InitializeComponent();
        }
        public PRO_T001(string ts_code, STD_LIST_BE REF_OBJECT)
        {
            ts_code_vm = ts_code;
            this.DataContext = new PRO_T001_VM(ts_code, REF_OBJECT);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
            InitializeComponent();
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
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "PRO_T001_VM")
            {
                prioritypopup.IsOpen = false;
                emppopup.IsOpen = false;
                _popup_status.IsOpen = false;
                popup_PurGrp.IsOpen = false;
                _popupPlant.IsOpen = false;
                deptpopup.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != prioritypopup)
            {
                var msg = new NotificationMessage("PRO_T001_VM");
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void HandleDataGridGotFocus(object sender, RoutedEventArgs e) // REF_TBD: pending this logic of Key Enter need to set on all screen datagrid.
        {
            DataGrid grid = (DataGrid)sender;
            try
            {
                if (e.OriginalSource is DataGridCell cell && !cell.IsEditing && dgKey == null)
                {
                    grid.BeginEdit(e);
                    if (grid.CurrentCell != null && (grid.CurrentCell.Column is DataGridBoundColumn || grid.CurrentCell.Column is DataGridTemplateColumn))
                    {
                        grid.BeginEdit(e);
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            TextBox textBox = UIServices.FindVisualChild<TextBox>(cell);
                            if (textBox != null && textBox.IsVisible)
                            {
                                textBox.Focus();
                                textBox.ForceCursor = true;
                                textBox.CaretIndex = textBox.Text.Length;
                                textBox.SelectAll();
                            }
                        }), System.Windows.Threading.DispatcherPriority.Background);
                    }
                }
                dgKey = null; // Set to null once finish.
            }
            catch(Exception ex) { dgKey = null; }
        }
        private void DataGrid_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            // Get the DataGridCell that is currently focused.
            //DataGridCell cell = GetCurrentCell(dataGrid);
            DataGrid grid = (DataGrid)sender;
            if (grid.CurrentCell != null)
            {
                // Check which key was pressed.
                if (e.Key == Key.Enter)
                {
                    dgKey = "Enter";
                }
                else
                {
                    dgKey = null;
                }
            }
        }
    }
}
