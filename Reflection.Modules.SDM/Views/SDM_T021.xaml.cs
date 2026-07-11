using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Modules.SDM.ViewModels;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Services;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Reflection.Modules.SDM.Views
{
    /// <summary>
    /// Interaction logic for SDM_T021.xaml
    /// </summary>
    public partial class SDM_T021 : WindowElement
    {
        ControlsEventHandler ceh = new ControlsEventHandler();
        public string ts_code_vm { get; set; }
        public string dgKey { get; set; } = null;
        public SDM_T021(string ts_code)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T005_VM(ts_code, "SO", "RS");
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T021(string ts_code, string doc_no)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T005_VM(ts_code, "SO", "RS", doc_no);
            tbcMaster.SelectionChanged += TabControl_SelectionChanged;
            tbcDetail.SelectionChanged += TabControl_SelectionChanged;
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T021(string ts_code, STD_LIST_BE STD_OBJECT)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new SDM_T005_VM(ts_code, STD_OBJECT);
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private bool isManualEditCommit;

        //This will update the bound object whenever a cell edit is ending, i.e.whenever the cell looses focus.
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

        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source != _popup_SoldToParty)
            {
                var msg = new NotificationMessage(ts_code_vm);
                this.Dispatcher.BeginInvoke((Action)(() =>
                {
                    NotificationMessageReceived(msg);
                }));
                e.Handled = true;
            }
        }

        private void btnTPOPUP_Click(object sender, RoutedEventArgs e)
        {
            //ppItemInfo.IsOpen = true;
        }
        //private ControlsEventHandler eventHandler = new ControlsEventHandler();
        // Working Properly on Got focus, just on Enter it shift to right instead of down cell. also need movement on arrow key. Also need DataGrid name which is not good for generic function fo rall screens.
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

        /// <summary>
        ///  All below functions related to cell got focus is now not using and shifted to UIServices in service project.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // Working with this event but not using because not perfectly workin on just gotFocus
        private void HandleDataGridCellBeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (e.Column is DataGridBoundColumn boundColumn && e.Row is DataGridRow row)
            {
                // Get the DataGridCell container for the cell being edited
                DataGridCell cell = boundColumn.GetCellContent(row) as DataGridCell;

                if (cell != null)
                {
                    // Find the TextBox within the cell
                    TextBox textBox = UIServices.FindVisualChild<TextBox>(cell);

                    if (textBox != null && textBox.IsVisible)
                    {
                        // Set the focus to the TextBox and place the cursor at the end
                        textBox.Focus();
                        textBox.Select(textBox.Text.Length, 0);
                    }
                }
            }
        }
        // Not Working with this event
        private void HandleDataGridPreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {

            if (e.Column is DataGridBoundColumn boundColumn && e.Row is DataGridRow row)
            {
                // Get the DataGridCell container for the cell being edited
                DataGridCell cell = boundColumn.GetCellContent(row) as DataGridCell;

                if (cell != null)
                {
                    // Find the TextBox within the cell
                    TextBox textBox = UIServices.FindVisualChild<TextBox>(cell);

                    if (textBox != null && textBox.IsVisible)
                    {
                        // Delay the focus setting to ensure it occurs after the cell enters edit mode
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            // Set the focus to the TextBox in the cell and place the cursor at the end
                            textBox.Focus();
                            textBox.Select(textBox.Text.Length, 0);
                        }), System.Windows.Threading.DispatcherPriority.Background);
                    }
                }
            }
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
        // NOTE: make this as generic function in service module and use throughtout system. We have use this before so make single one.
        //private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        //{
        //    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        //    {
        //        DependencyObject child = VisualTreeHelper.GetChild(parent, i);

        //        if (child is T typedChild)
        //        {
        //            return typedChild;
        //        }

        //        T childOfChild = FindVisualChild<T>(child);

        //        if (childOfChild != null)
        //        {
        //            return childOfChild;
        //        }
        //    }

        //    return null;
        //}

    }
}
