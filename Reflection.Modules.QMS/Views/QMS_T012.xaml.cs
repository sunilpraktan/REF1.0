using System;
using System.Windows.Controls;
using Reflection.Modules.QMS.ViewModels;
using Reflection.Presentation.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.QMS;
using Reflection.Presentation.Services;
using System.Windows;
using System.Windows.Threading;

namespace Reflection.Modules.QMS.Views
{
    /// <summary>
    /// Interaction logic for QMS_T012.xaml
    /// </summary>
    public partial class QMS_T012 : WindowElement
    {
        public string ts_code_vm { get; set; }
        private bool isManualEditCommit;
        public QMS_T012(string ts_code, string doc_no, QMS_T003 lot_info)
        {
            this.ts_code_vm = ts_code;
            InitializeComponent();
            this.DataContext = new QMS_T003_RR_VM(ts_code, doc_no, lot_info);
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
                
            }
        }
        private void HandleGotFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                
                if (e.OriginalSource is DataGridCell cell && !cell.IsEditing)
                {
                    DataGrid grid = (DataGrid)sender;

                    grid.BeginEdit(e);
                    if (grid.CurrentCell != null && (grid.CurrentCell.Column is DataGridBoundColumn || grid.CurrentCell.Column is DataGridTemplateColumn))
                    {
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
                else if (e.OriginalSource is TextBox text)
                {
                    TextBox tbInput = (TextBox)sender;
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        TextBox textBox = UIServices.FindVisualChild<TextBox>(text);
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
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the InnerException to see the original exception details
                    var innerException = ex.InnerException;
                    // Handle or log the inner exception
                }
            }
        }

        private void DataGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            var grid = (DataGrid)sender;
            grid.CommitEdit(DataGridEditingUnit.Row, true);
            grid.CommitEdit();
            grid.CommitEdit();
        }

        private void TxtMultiselect_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Background, new System.Action(() =>
            {
                // Check if the focus is outside the Popup
                if (!tb.IsKeyboardFocusWithin && !tb.IsKeyboardFocusWithin)
                {
                    // Close the Popup
                    //ppMultiselect.IsOpen = false;
                    tb.Focus();
                    tb.ForceCursor=true;
                    tb.CaretIndex= tb.Text.Length;
                    tb.SelectAll();
                    e.Handled = true;
                }
            }));
        }

        //private async Task DeferRefreshAsync()
        //{
        //    var collectionView = CollectionViewSource.GetDefaultView(yourDataCollection) as ICollectionView;

        //    if (collectionView.IsAddingNew || collectionView.IsEditingItem)
        //    {
        //        collectionView.CommitEdit(); // or collectionView.CancelEdit();

        //        await Task.Delay(1); // Give some time for the commit/cancel to complete

        //        Application.Current.Dispatcher.Invoke(() =>
        //        {
        //            collectionView.DeferRefresh();
        //            collectionView.Refresh(); // Apply the deferred changes
        //        }, DispatcherPriority.Background);
        //    }
        //    else
        //    {
        //        collectionView.DeferRefresh();
        //        collectionView.Refresh(); // Apply the changes
        //    }
        //}

    }
}
