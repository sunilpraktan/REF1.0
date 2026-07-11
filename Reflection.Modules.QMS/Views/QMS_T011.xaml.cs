using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.QMS.Views
{

    public partial class QMS_T011 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public string dgKey { get; set; } = null;
        private bool isManualEditCommit;

        public QMS_T011(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new QMS_T011_VM(ts_code,"IL");
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public QMS_T011(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new QMS_T011_VM(ts_code,"IL", doc_no);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
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

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == this.ts_code_vm)
            {
                popFilterSearch.IsOpen = false;
            }
        }
        private void HandleDataGridGotFocus(object sender, RoutedEventArgs e)
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
            catch (Exception ex) { dgKey = null; }
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
