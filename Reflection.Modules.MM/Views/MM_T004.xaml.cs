using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.MM.ViewModels;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reflection.Modules.MM.Views
{
    /// <summary>
    /// Interaction logic for MM_T001.xaml
    /// </summary>
    public partial class MM_T004 : WindowElement
    {
        public string ts_code_vm { get; set; }
        public string dgKey { get; set; } = null;
        public MM_T004(string ts_code)
        {
            ts_code_vm = ts_code;
            this.DataContext = new MM_T005_VM("MR",ts_code);
            InitializeComponent();
        }
        public MM_T004(string ts_code, string doc_no)
        {
            InitializeComponent();
            this.DataContext = new MM_T005_VM("MR", ts_code, doc_no);
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
