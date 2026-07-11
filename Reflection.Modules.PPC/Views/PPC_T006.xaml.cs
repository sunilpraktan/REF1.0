using GalaSoft.MvvmLight.Messaging;
using Reflection.Modules.PPC.ViewModels;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Reflection.Modules.PPC.Views
{
    /// <summary>
    /// Interaction logic for PPC_T006.xaml
    /// </summary>
    public partial class PPC_T006 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;

        public PPC_T006(string ts_code)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PPC_T006_VM(ts_code, "02");
        }
        public PPC_T006(string ts_code, string doc_no)
        {
            InitializeComponent();
            ts_code_vm = ts_code;
            this.DataContext = new PPC_T006_VM(ts_code, "02", doc_no);
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

                //ppQRBarcode.IsOpen = false;
                //ppOrderNo.IsOpen = false;
            }
        }
        private void mainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.Source != ppOrderNo)
            //{
            //    this.Dispatcher.BeginInvoke((Action)(() =>
            //    {
            //        NotificationMessageReceived(new NotificationMessage(ts_code_vm));
            //    }));
            //    e.Handled = true;
            //}
        }

        private void DgDataTemp_PreparingCellForEdit(object sender, DataGridPreparingCellForEditEventArgs e)
        {
            // Find the TextBox within the cell's template
            var cell = e.EditingElement as FrameworkElement;
            var textBox = FindVisualChild<TextBox>(cell);

            // Set the focus and cursor position
            if (textBox != null)
            {
                textBox.Focus();
                textBox.SelectAll(); // Optional: Select all text in the TextBox
            }
        }
        private T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            int childCount = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < childCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is T foundChild)
                    return foundChild;

                var result = FindVisualChild<T>(child);
                if (result != null)
                    return result;
            }

            return null;
        }
    }
}
