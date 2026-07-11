using System;
using System.Windows.Controls;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.QMS;
using System.Windows.Input;
using System.Windows;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using System.Security.Cryptography;

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for QMS_T014.xaml
    /// </summary>
    public partial class QMS_T014 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public string dgKey { get; set; } = null;
        private bool isManualEditCommit;
        public QMS_T014(STD_LIST_BE STD_OBJ, QMS_T003 LOT_INFO)
        {
            this.ts_code_vm = STD_OBJ.ts_code;
            InitializeComponent();
            this.DataContext = new QMS_T003_UD_VM(STD_OBJ, LOT_INFO);
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
            if (msg.Notification == ts_code_vm)
            {
                //popStoreCode.IsOpen = false;
                //popStoreCodeB.IsOpen = false;
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
