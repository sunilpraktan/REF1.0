using Reflection.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Reflection.Presentation.Controls
{
    /// <summary>
    /// This class section designed for common generic event handler for UI control.
    /// NOTE: now not in use because on focus to datagrid textbox, content not get selected with cursor location at end to edit. once it is resolved then we can replace all screens codebehind as per new reusable function of this class.
    /// </summary>
    public class ControlsEventHandler
    {
        private Dispatcher _dispatcher;

        //public TextBoxEventHandler(Dispatcher dispatcher)
        //{
        //    _dispatcher = dispatcher;
        //}
        public void HandleDataGridGotFocus(object sender, RoutedEventArgs e)
        {
            // Add your event handler code here
            // This method will be used for handling the PreviewKeyDown event of TextBox controls
            // You can access the TextBox properties and perform actions accordingly

            DataGrid grid = (DataGrid)sender;
            if (e.OriginalSource is DataGridCell cell && !cell.IsEditing)
            {
                grid.BeginEdit(e);
                if (grid.CurrentCell != null && (grid.CurrentCell.Column is DataGridBoundColumn || grid.CurrentCell.Column is DataGridTemplateColumn))
                {
                    _dispatcher.BeginInvoke(new Action(() =>
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
        }


        //public static void TextBox_PreviewKeyDown(object sender, RoutedEventArgs e) // KeyEventArgs
        //{
        //    // Add your event handler code here
        //    // This method will be used for handling the PreviewKeyDown event of TextBox controls
        //    // You can access the TextBox properties and perform actions accordingly
        //}
    }
}
