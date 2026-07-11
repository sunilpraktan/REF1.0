using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reflection.Apps.Store.TaskManager
{
    /// <summary>
    /// Interaction logic for EditTaskView.xaml
    /// </summary>
    public partial class EditTaskView : UserControl
    {
        private bool m_hasTask = false;

        #region Constructors

        public EditTaskView()
        {
            InitializeComponent();
            this.DataContext = new EditTask(); //extra added code
            DataContextChanged += (sender, args) =>
            {
                if (DataContext != null)
                {
                    m_textBox.Focus();
                }
                else
                {
                    CloseEditor(false);
                }
            };
        }

        #endregion Constructors

        #region Properties

        public bool HasTask
        {
            get { return m_hasTask; }
            set { m_hasTask = value; }
        }

        #endregion Properties

        #region Event Handlers

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommitTask(false);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CloseEditor(false);
        }

        private void m_textBox_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            ShowEditor();
        }

        private void m_textBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!this.HasTask)
            {
                ShowEditor();
                e.Handled = true;
            }
        }

        private void m_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text))
            {
                ShowEditor();
            }
        }

        #endregion Event Handlers

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (!e.Handled)
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    CommitTask(Keyboard.Modifiers == ModifierKeys.Control);
                    e.Handled = true;
                }
                else if (e.Key == Key.Escape)
                {
                    CloseEditor(true);
                    e.Handled = true;
                }
            }

            base.OnKeyDown(e);
        }

        #region Private Methods

        private void CancelTask()
        {
            Commands.Cancel.Execute(null, this as IInputElement);
        }

        private void CloseEditor(bool moveFocus)
        {
            TaskDetailsReveal.IsExpanded = false;
            HasTask = false;

            if (moveFocus)
            {
                TraversalRequest request = new TraversalRequest(FocusNavigationDirection.Next);

                // Gets the element with keyboard focus.
                UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;

                // Change keyboard focus.
                if (elementWithFocus != null)
                {
                    elementWithFocus.MoveFocus(request);
                }
            }
        }

        private void CommitTask(bool keepEditorOpen)
        {
            var newTask = this.DataContext as EditTask;

            if (newTask != null && !newTask.HasErrors)
            {
                newTask.Commit();
                this.HasTask = false;

                if (keepEditorOpen)
                {
                    ShowEditor();
                }
                else
                {
                    CloseEditor(true);
                }
            }

        }

        private void ShowEditor()
        {
            if (!this.HasTask)
            {
                HasTask = true;
                ApplicationCommands.New.Execute(null, this as IInputElement);

                var folder = TaskManagerView.Root.TaskData.CurrentFolder;

                if (!folder.IsSpecial)
                {
                    (DataContext as EditTask).TaskString = " in: " + folder.Name;
                    m_textBox.CaretIndex = 0;
                }

            }
            TaskDetailsReveal.IsExpanded = true;
        }

        #endregion Private Methods

        private void FolderDropDown_RequestFolderChange(object sender, RequestFolderChangeEventArgs e)
        {            
            var editTask = DataContext as EditTask;
            (DataContext as EditTask).Task = editTask.Task;
            if (editTask != null && editTask.Task == e.Task)
            {
                editTask.Task.FolderName = e.FolderName;
                editTask.Task.folder_id = e.folder_id;//extra added code
                
            }
        }
    }
}
