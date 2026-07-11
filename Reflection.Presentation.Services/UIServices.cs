using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Reflection.Presentation.Services
{
    public static class UIServices
    {
        // Find child or any control in Visual Tree of UI like DataGrid cell from templeted column with the help of name or id
        public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                if (child is T typedChild)
                {
                    return typedChild;
                }

                T childOfChild = FindVisualChild<T>(child);

                if (childOfChild != null)
                {
                    return childOfChild;
                }
            }

            return null;
        }

        //Remove Duplicate from comma seperated string
        public static string RemoveDuplicates(string input)
        {
            string[] elements = input.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries); //NOTE: if updgrade to next framework use StringSplitOptions.TrimEntries option 

            // Create a HashSet to store unique elements
            HashSet<string> uniqueElements = new HashSet<string>(elements);
            // Join the unique elements back into a string excluding extra chars and spaces
            string result = string.Join(",", uniqueElements.Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)));

            //NOTE: Repeating function because in one step it not remove all whohe have spce at prefix. if clear in first attempt then we can remove double filter.
            elements = result.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries); //NOTE: if updgrade to next framework use StringSplitOptions.TrimEntries option 
            HashSet<string> uniqueElements2 = new HashSet<string>(elements);
            result = string.Join(",", uniqueElements2.Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)));
            //string result = string.Join(",", uniqueElements.Select(x => x.Trim()).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray());

            // Join the unique elements back into a string
            //string result = string.Join(",", uniqueElements);

            return result;
        }

        public static string GetBindingPath(DataGridColumn dgColumn)
        {
            string ColumnPath = null;
            try
            {
                if (dgColumn is DataGridTextColumn textColumn)
                {
                    ColumnPath = textColumn.SortMemberPath;
                    if (string.IsNullOrWhiteSpace(ColumnPath))
                    {
                        ColumnPath = ((System.Windows.Data.Binding)((System.Windows.Controls.DataGridBoundColumn)dgColumn).Binding).Path.Path.ToString();
                    }
                }
                else if (dgColumn is DataGridComboBoxColumn comboBoxColumn)
                {
                    ColumnPath = comboBoxColumn.SortMemberPath;
                    if (string.IsNullOrWhiteSpace(ColumnPath))
                    {
                        ColumnPath = ((System.Windows.Data.Binding)((System.Windows.Controls.DataGridBoundColumn)dgColumn).Binding).Path.Path.ToString();
                    }
                }
                else if (dgColumn is DataGridCheckBoxColumn checkBoxColumn)
                {
                    ColumnPath = checkBoxColumn.SortMemberPath;
                    if (string.IsNullOrWhiteSpace(ColumnPath))
                    {
                        ColumnPath = ((System.Windows.Data.Binding)((System.Windows.Controls.DataGridBoundColumn)dgColumn).Binding).Path.Path.ToString();
                    }
                }
                else if (dgColumn is DataGridTemplateColumn templateColumn)
                {
                    ColumnPath = templateColumn.SortMemberPath;
                }

                return ColumnPath;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}
