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
    /// Interaction logic for FolderDropDown.xaml
    /// </summary>
    public partial class FolderDropDown : UserControl
    {
        #region Constructors

        public FolderDropDown()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        private BaseTask TaskContext
        {
            get
            {
                var tvm = DataContext as TaskViewModel;
                if (tvm == null)
                {
                    var editTask = DataContext as EditTask;
                    if (editTask == null)
                    {
                        return null;
                    }
                    else
                    {
                        return editTask.Task;
                    }
                }
                else
                {
                    return tvm.Task;
                }
            }
        }

        #endregion Properties

        #region Events

        public event EventHandler<RequestFolderChangeEventArgs> RequestFolderChange;

        #endregion Events

        #region Event Handlers

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Folder f = ((Button)sender).DataContext as Folder;
            close(new RequestFolderChangeEventArgs(TaskContext, f != null ? f.Name : null));
            //if (NewFolderTextBox.Text != null) //extra code
            //{
            //    FolderButton.DataContext = NewFolderTextBox.Text;
            //}
        }

        private void Popup_Opened(object sender, EventArgs e)
        {
            NewFolderTextBox.Text = TaskContext.folder_name;

            NewFolderTextBox.Focus();

            if (NewFolderTextBox.Text != null)
            {
                NewFolderTextBox.SelectAll();
            }
        }

        #endregion Event Handlers

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (m_popup.IsOpen)
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    close(new RequestFolderChangeEventArgs(TaskContext, NewFolderTextBox.Text));
                    e.Handled = true;
                }
            }
            //base.OnKeyDown(e); //commented by Priyanka
            base.OnPreviewKeyDown(e);
        }

        #region Private Methods

        private void close(RequestFolderChangeEventArgs args)
        {
            m_popup.IsOpen = false;

            var handler = RequestFolderChange;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        #endregion Private Methods

    }

    public class RequestFolderChangeEventArgs : EventArgs
    {
        #region Constructors

        public RequestFolderChangeEventArgs(BaseTask task, string folderName)
        {
            Task = task;
            FolderName = folderName;
        }

        #endregion Constructors

        #region Properties

        public string FolderName { get; private set; }

        public int folder_id { get; private set; } // extra added

        public BaseTask Task { get; private set; }

        #endregion Properties
    }
}
